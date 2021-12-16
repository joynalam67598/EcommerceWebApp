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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository = null ;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: CategoryController
        public ViewResult AddCategory(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
        {
            if(ModelState.IsValid)
            {
               var categoryId = await _categoryRepository.AddCategory(categoryModel);
               if (categoryId > 0)
               {
                  return RedirectToAction(nameof(AddCategory), 
                      new { isSuccess = true, categoryId });
               }
            }
            ModelState.AddModelError("", "This is something error message");
            return View();
        }

        public async Task<ViewResult> ManageCategories(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            var categories = await _categoryRepository.GetAllCategories();
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
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

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _categoryRepository.GetCategory(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryRepository.UpdateCategory(categoryModel);
                    return RedirectToAction(nameof(ManageCategories),
                      new { isSuccess = true});
                }
                catch
                {
                    ModelState.AddModelError("", "This is something error message");
                    return View(categoryModel);
                }
            }
            return View(categoryModel);
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _categoryRepository.DeleteCategory(id);
            return RedirectToAction(nameof(ManageCategories),
                      new { isSuccess = true });
        }

        // POST: CategoryController/Delete/5
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
