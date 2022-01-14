using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public AdministrationRepository(AlishaMartContext alishaMartContext,
            RoleManager<IdentityRole> roleManager)
        {
            _alishaMartContext = alishaMartContext;
            _roleManager = roleManager;
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
    }
}
