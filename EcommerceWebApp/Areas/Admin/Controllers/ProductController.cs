using EcommerceWebApp.Models;
using EcommerceWebApp.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Areas.Admin.Views.Product
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IBrandRepository _brandRepository = null;
        private readonly ICategoryRepository _categoryRepository = null;
        private readonly IProductRepository _productRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public ProductController(IBrandRepository brandRepository,
            ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment,
            IProductRepository productRepository)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: ProductController
        public async Task<ViewResult> Index(string status = "")
        {
            ViewBag.status = status;
            var products = await _productRepository.GetAllProducts();
            return View(products);
        }

        // GET: ProductController/Details/5
        public async Task<ViewResult> Details(int id)
        {
            var product = await _productRepository.GetProductDetails(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ViewResult Create(string status = "",int bookId=0)
        {
            ViewBag.status = status;
            ViewBag.bookId = bookId;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            if(ModelState.IsValid)
            {
                if (productModel.CoverImage != null)
                {
                    string path = "images/product/cover/";
                    productModel.CoverImageUrl = await UploadImage(path, productModel.CoverImage);
                }
                if(productModel.ProductImages!=null)
                {
                    string path = "images/product/gellary/";
                    productModel.ProductImage = new List<ProductImageModel>();
                    foreach(var image in productModel.ProductImages)
                    {
                        var productImage = new ProductImageModel()
                        {
                            Name = productModel.ProductName,
                            Url = await UploadImage(path, image)
                        };
                        productModel.ProductImage.Add(productImage);
                    }
                }
                var message = await _productRepository.AddProduct(productModel);
                if(message != null) return RedirectToAction(nameof(Create), new { status = message});
            }
            ModelState.AddModelError("", "This is something error message");
            return View();
            
        }

        // GET: ProductController/Edit/5
        public async Task<ViewResult> Edit(int id)
        {
            var product = await _productRepository.GetProductDetails(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductModel productModel)
        {
            if (ModelState.IsValid)
                {
                    if (productModel.CoverImage != null)
                    {
                        string path = "images/product/cover/";
                        productModel.CoverImageUrl = await UploadImage(path, productModel.CoverImage);
                    }
                    if (productModel.ProductImages != null)
                    {
                        string path = "images/product/gellary/";
                        productModel.ProductImage = new List<ProductImageModel>();
                        foreach (var image in productModel.ProductImages)
                        {
                            var productImage = new ProductImageModel()
                            {
                                Name = productModel.ProductName,
                                Url = await UploadImage(path, image)
                            };
                            productModel.ProductImage.Add(productImage);
                        }
                    }
                    var message = await _productRepository.UpdateProduct(productModel);
                    if (message != null) return RedirectToAction(nameof(Index), new { status = message });
                }
                ModelState.AddModelError("", "This is something error message");
                return View();
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _productRepository.DeleteProduct(id);
            if(message!="")
            {
                return RedirectToAction(nameof(Index), new { status = message });
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
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

        public async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.Name;
            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/"+folderPath;
        }
    }
}
