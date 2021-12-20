using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AlishaMartContext _alishaMartContext = null;
        public ProductRepository(AlishaMartContext alishaMartContext)
        {
            _alishaMartContext = alishaMartContext;
        }
        public async Task<int> AddProduct(ProductModel productModel)
        {
            var newProduct = new Products()
            {
                ProductName = productModel.ProductName,
                ProductCode = productModel.ProductCode,
                CategoryId = productModel.CategoryId,
                BrandId = productModel.BrandId,
                AvailableQuantity = productModel.AvailableQuantity,
                BuyingPrice = productModel.BuyingPrice,
                SellingPrice = productModel.SellingPrice,
                Status = false,
                Description = productModel.Description,
                StockInDate = DateTime.UtcNow,
                CoverImageUrl = productModel.CoverImageUrl,
            };

            newProduct.ProductImages = new List<ProductImages>();

            foreach (var image in productModel.ProductImage)
            {
                newProduct.ProductImages.Add(new ProductImages()
                {
                    Name = productModel.ProductName,
                    Url = image.Url,
                });

            }
            _alishaMartContext.Products.Add(newProduct);
            await _alishaMartContext.SaveChangesAsync();

            return newProduct.Id;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _alishaMartContext.Products.Select(product => new ProductModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                BuyingPrice = product.BuyingPrice,
                SellingPrice = product.SellingPrice,
                AvailableQuantity = product.AvailableQuantity,
                StockInDate = product.StockInDate.GetValueOrDefault().Date,
            }).ToListAsync();
        }

        public async Task<ProductModel> GetProductDetails(int productId)
        {
            return await _alishaMartContext.Products.Where(product => product.Id == productId)
                .Select(product => new ProductModel()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductCode = product.ProductCode,
                    BrandId = product.BrandId,
                    BrandName = product.Brand.BrandName,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.CategoryName,
                    BuyingPrice = product.BuyingPrice,
                    SellingPrice = product.SellingPrice,
                    AvailableQuantity = product.AvailableQuantity,
                    StockInDate = product.StockInDate.GetValueOrDefault().Date,
                    CoverImageUrl = product.CoverImageUrl,
                    Description = product.Description,
                    ProductImage = product.ProductImages.Select(image => new ProductImageModel()
                    {
                        Id = image.Id,
                        Name = image.Name,
                        Url = image.Url,
                    }).ToList()

                }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateProduct(ProductImageModel updatedProduct)
        {
            var product =await _alishaMartContext.ProductImages.FindAsync(updatedProduct.Id);
            return 1;

        }
    }
}
