using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(UserModel userModel);
        Task<List<UserModel>> GetAllUsers();
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
    }
}