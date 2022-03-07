using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public interface IAdministrationRepository
    {
        Task<string> AddRole(RoleModel roleModel);
        Task<RoleModel> GetUserRoles(string userId);
        Task<int> UpdateUserRole(RoleModel roleModel);
    }
}