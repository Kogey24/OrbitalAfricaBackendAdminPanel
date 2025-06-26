using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Orbital_Africa_Backend_Recon.Models;
using Orbital_Africa_Backend_Recon.Service;

namespace Orbital_Africa_Backend_Recon.Container
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly OrbitalAfricaContext context;
        public RefreshHandler(OrbitalAfricaContext context)
        {
            this.context = context;
        }
        public async Task<string> GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using(var randomnumbergenerator =RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string refreshtoken=Convert.ToBase64String(randomnumber);
                var ExistToken = await this.context.TblrefreshTokens.FirstOrDefaultAsync(item => item.Userid == username);
                if (ExistToken != null)
                {
                    ExistToken.Refreshtoken = refreshtoken;
                }
                else
                {
                    await this.context.TblrefreshTokens.AddAsync(new TblrefreshToken
                    {
                        Userid = username,
                        Tokenid = new Random().Next().ToString(),
                        Refreshtoken = refreshtoken
                    });
                }
                await this.context.SaveChangesAsync();
                return refreshtoken;
            }
        }
    }
}
