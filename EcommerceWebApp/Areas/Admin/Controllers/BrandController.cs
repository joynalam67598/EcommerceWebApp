using EcommerceWebApp.Models;
using EcommerceWebApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository = null;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        // GET: BrandController
        public ViewResult AddBrand(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                var brandId =  _brandRepository.AddBrand(brandModel);
                if (brandId > 0)
                {
                    return RedirectToAction(nameof(AddBrand),
                        new { isSuccess = true, brandId });
                }
            }
            ModelState.AddModelError("", "This is something error message");
            return View();
        }

        public async Task<ViewResult> ManageBrands()
        {
            var brands = await _brandRepository.GetAllBrands();
            return View(brands);
        }

        // GET: BrandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brand = await _brandRepository.GetBrand(id);
            return View(brand);
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _brandRepository.UpdateBrand(brandModel);
                    return RedirectToAction(nameof(ManageBrands),
                      new { isSuccess = true });
                }
                catch
                {
                    ModelState.AddModelError("", "This is something error message");
                    return View(brandModel);
                }
            }
            return View(brandModel);
        }

        // GET: BrandController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _brandRepository.DeleteBrand(id);
            return RedirectToAction(nameof(ManageBrands),
                      new { isSuccess = true });
        }

        // POST: BrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
