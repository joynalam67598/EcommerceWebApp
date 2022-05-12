using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AlishaMartContext _alishaMartContext = null;
        private readonly UserManager<ApplicationUser> _userManager = null;
        private  readonly SignInManager<ApplicationUser> _signInManager = null;
        public UserRepository(AlishaMartContext alishaMartContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _alishaMartContext = alishaMartContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(UserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email,
                PhoneNumber = userModel.PhoneNumber,                
                BirthDate = userModel.BirthDate,
                City = userModel.City,
                Address = userModel.Address
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
            //if(result.Succeeded) return "User added successfully.";
            //return "Something went wrong.";
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _userManager.Users.Select(user => new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            }).ToListAsync();
        }
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var user = await _userManager.FindByEmailAsync(signInModel.Email);
            var ok = await _userManager.CheckPasswordAsync(user, signInModel.Password);
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
