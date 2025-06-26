using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Orbital_Africa_Backend_Recon.Modal;
using Orbital_Africa_Backend_Recon.Models;
using Orbital_Africa_Backend_Recon.Service;

namespace Orbital_Africa_Backend_Recon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly OrbitalAfricaContext context;
        private readonly JwtSettings jwtSettings;
        private readonly IRefreshHandler refresh;
        public AuthorizeController(OrbitalAfricaContext context, IOptions<JwtSettings> options, IRefreshHandler refresh)
        {
            this.context = context;
            this.jwtSettings = options.Value;
            this.refresh = refresh;
        }
        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] UserCred usercred)
        {
            var user = await this.context.TblUsers.FirstOrDefaultAsync(item => item.Username == usercred.username && item.Password == usercred.password);
            if (user != null)
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
                var tokendesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Role,user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenhandler.CreateToken(tokendesc);
                var finaltoken = tokenhandler.WriteToken(token);
                return Ok(finaltoken);
            }
            else
            {
                return Unauthorized();
            }
            return Ok();
        }

        [HttpPost("GenerateRefreshToken")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenResponse token)
        {
            var _refreshtoken = await this.context.TblrefreshTokens.FirstOrDefaultAsync(item => item.Refreshtoken == token.RefreshToken);

            if (_refreshtoken != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
                SecurityToken securityToken;

                var principal = tokenHandler.ValidateToken(token.Token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out securityToken);

                var _token = securityToken as JwtSecurityToken;

                if (_token != null && _token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
                {
                    string username = principal.Identity.Name;

                    var _existdata = await this.context.TblrefreshTokens.FirstOrDefaultAsync(item => item.Userid == username && item.Refreshtoken == token.RefreshToken);

                    if (_existdata != null)
                    {
                        var _newtoken = new JwtSecurityToken(
                            claims: principal.Claims.ToArray(),
                            expires: DateTime.Now.AddSeconds(30),
                            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                        );

                        var _finalToken = tokenHandler.WriteToken(_newtoken);

                        return Ok(new TokenResponse()
                        {
                            Token = _finalToken,
                            RefreshToken = await this.refresh.GenerateToken(username)
                        });
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
