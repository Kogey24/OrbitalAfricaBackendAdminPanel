namespace Orbital_Africa_Backend_Recon.Service
{
    public interface IRefreshHandler
    {
        Task<string> GenerateToken(string username);
    }
}
