using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(UserModel userModel);
    }
}