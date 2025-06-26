using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Orbital_Africa_Backend_Recon.Container;
using Orbital_Africa_Backend_Recon.Modal;
using Orbital_Africa_Backend_Recon.Modal.Email;
using Orbital_Africa_Backend_Recon.Modal.Helper;
using Orbital_Africa_Backend_Recon.Models;
using Orbital_Africa_Backend_Recon.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionstring = builder.Configuration.GetConnectionString("constring");
builder.Services.AddDbContext<OrbitalAfricaContext>(o => o.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));
builder.Services.AddTransient<IuserService, UserService>();
builder.Services.AddTransient<IUserRoleService, UserRoleService>();
builder.Services.AddTransient<IRefreshHandler, RefreshHandler>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

var _authkey = builder.Configuration.GetValue<string>("JwtSettings:securitykey");
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});



var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
 

app.MapControllers();

app.Run();
