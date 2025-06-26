using Orbital_Africa_Backend_Recon.Modal;

namespace Orbital_Africa_Backend_Recon.Service
{
    public interface IuserService
    {
        Task<APIResponse> UserRegistration(UserRegister userRegister);
        Task<APIResponse> CustomerRegistration(CustomerRegister customer);
        Task<APIResponse> ConfirmRegistration(int userid, string username, string otptext);
        Task<APIResponse> ResetPassword(string username, string oldpassword, string newpassword);
        Task<APIResponse> ForgotPassword(string username);
        Task<APIResponse> UpdatePassword(string username, string password, string otptext);
        Task<APIResponse> UpdateStatus(string username, bool userstatus);
        Task<APIResponse> UpdateRole(string username, string userrole);
        Task <List<UserModal>> GetUsers();
    }
}
