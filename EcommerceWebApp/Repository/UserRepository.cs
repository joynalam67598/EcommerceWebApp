using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Identity;
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
        public UserRepository(AlishaMartContext alishaMartContext,
            UserManager<ApplicationUser> userManager)
        {
            _alishaMartContext = alishaMartContext;
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(UserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.FirstName,
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
    }
}
