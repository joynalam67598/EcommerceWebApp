using EcommerceWebApp.Models;
using EcommerceWebApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager = null;
        private readonly IAdministrationRepository _administrationRepository;
        private readonly IUserRepository _userRepository;


        public AdministrationController(RoleManager<IdentityRole> roleManager,
            IAdministrationRepository administrationRepository, IUserRepository userRepository)
        {
            _roleManager = roleManager;
            _administrationRepository = administrationRepository;
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult AddRole(string status = "")
        {
            ViewBag.status = status;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleModel roleModel)
        {
            if(ModelState.IsValid)
            {
                var message = await _administrationRepository.AddRole(roleModel);
                if (message != null) return RedirectToAction(nameof(AddRole), new { status = message });
            }
            ModelState.AddModelError("", "This is something error message");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ManageRole()
        {
            var users = await _userRepository.GetAllUsers();
            return View(users);
        }
        [HttpGet]
        
        // GET: AdministrationController/EditUserRole/5
        public async Task<IActionResult> EditUserRole(string Id)
        {
            var userRole = await _administrationRepository.GetUserRoles(Id);
            return View(userRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: AdministrationController/EditUserRole/5
        public async Task<IActionResult> EditUserRole(RoleModel roleModel)
        {
             try
                {
                    await _administrationRepository.UpdateUserRole(roleModel);
                    return RedirectToAction(nameof(ManageRole),
                      new { isSuccess = true });
                }
                catch
                {
                    ModelState.AddModelError("", "This is something error message");
                    return View(roleModel);
                }
        }

    }
}
