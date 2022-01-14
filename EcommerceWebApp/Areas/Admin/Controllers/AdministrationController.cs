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
        public AdministrationController(RoleManager<IdentityRole> roleManager,
            IAdministrationRepository administrationRepository)
        {
            _roleManager = roleManager;
            _administrationRepository = administrationRepository;
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


    }
}
