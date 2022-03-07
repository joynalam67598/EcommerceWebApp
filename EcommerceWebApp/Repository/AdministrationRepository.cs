using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly AlishaMartContext _alishaMartContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager = null;

        public AdministrationRepository(AlishaMartContext alishaMartContext,
            RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _alishaMartContext = alishaMartContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<string> AddRole(RoleModel roleModel)
        {
            IdentityRole newRole = new IdentityRole
            {
                Name = roleModel.RoleName

            };
            IdentityResult result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded) return "Role created successfully.";
            return "";
        }
        public async Task<RoleModel> GetUserRoles(string userId)
        {
            RoleModel userRole = new RoleModel();
            var user = await _alishaMartContext.Users.FindAsync(userId);
            var userInRole = await _alishaMartContext.UserRoles.Where(x=>x.UserId == userId).Select(x => x.RoleId).ToListAsync();
            userRole.ApplicationUser = user;
            userRole.ApplicationUserRole = await _roleManager.Roles.Select(x=>new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id,
                Selected = userInRole.Contains(x.Id)
            }).ToListAsync();
            return userRole; 
        }
        public async Task<int> UpdateUserRole(RoleModel roleModel)
        {
            var userId = roleModel.ApplicationUser.Id;
            var user = await _alishaMartContext.Users.FindAsync(userId);
            var selectedRoleId = roleModel.ApplicationUserRole.Where(x => x.Selected).Select(x => x.Value);
            var alreadyExists = await _alishaMartContext.UserRoles.Where(x => x.UserId == userId)
                .Select(x => x.RoleId).ToListAsync();
            var toAdd = selectedRoleId.Except(alreadyExists);
            var toRemove = alreadyExists.Except(selectedRoleId);

            foreach(var roleId in toRemove)
            {
                _alishaMartContext.UserRoles.Remove(new IdentityUserRole<string>()
                {
                    RoleId = roleId,
                    UserId = userId,
                });
            }
            foreach (var roleId in toAdd)
            {
                _alishaMartContext.UserRoles.Add(new IdentityUserRole<string>()
                {
                    RoleId = roleId,
                    UserId = userId,
                });
            }
            await _alishaMartContext.SaveChangesAsync();
            return 1;
        }

    }
}
