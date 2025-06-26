using Orbital_Africa_Backend_Recon.Modal;
using Orbital_Africa_Backend_Recon.Models;

namespace Orbital_Africa_Backend_Recon.Service
{
    public interface IUserRoleService
    {
        Task<APIResponse> AssignRolePermission(List<TblrolePermission> data);
        Task<List<Tblrole>> GetAllRoles();
        Task<List<Tblmenu>> GetAllMenu();
        Task<List<AppMenu>> GetAllMenubyRole(string userrole);
        Task<MenuPermission> GetMenuPermissionbyRole(string userrole, string menucode);
    }
}
