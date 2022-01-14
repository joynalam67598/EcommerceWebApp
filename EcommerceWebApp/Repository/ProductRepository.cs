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
        public async Task<string> AddProduct(ProductModel productModel)
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

            //newProduct.ProductImages = new List<ProductImages>();
            
            //foreach (var image in productModel.ProductImage)
            //{
            //    newProduct.ProductImages.Add(new ProductImages()
            //    {
            //        Name = productModel.ProductName,
            //        Url = image.Url,
            //    });

            //}
            _alishaMartContext.Products.Add(newProduct);
            await _alishaMartContext.SaveChangesAsync();

            return "New product added successfully.";
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

        public async Task<string> UpdateProduct(ProductModel updatedProduct)
        {
            var product =await _alishaMartContext.Products.FindAsync(updatedProduct.Id);
            if(product!=null)
            {
                product.ProductName = updatedProduct.ProductName;
                product.ProductCode = updatedProduct.ProductCode;
                product.BrandId = updatedProduct.BrandId;
                product.CategoryId = updatedProduct.CategoryId;
                product.BuyingPrice = updatedProduct.BuyingPrice;
                product.SellingPrice = updatedProduct.SellingPrice;
                product.AvailableQuantity = updatedProduct.AvailableQuantity;
                product.StockInDate = DateTime.UtcNow;
                if (updatedProduct.CoverImage != null)
                {
                    product.CoverImageUrl = updatedProduct.CoverImageUrl;
                }
                product.Description = updatedProduct.Description;
                _alishaMartContext.Update(product);
                await _alishaMartContext.SaveChangesAsync();
                return "Product information updated sucessfully.";
            }
            return "Something went wrong.";

        }
        public async Task<string> DeleteProduct(int productId)
        {
            var product = await _alishaMartContext.Products.FindAsync(productId);
            if(product.Id > 0)
            {
                var productImages = await _alishaMartContext.ProductImages
                    .Where(productImage => productImage.ProductsId == productId)
                    .Select(image => new ProductImageModel()
                    {
                        Id = image.Id,
                        Name = image.Name,
                        Url = image.Url,
                    }
                         
                    ).ToListAsync();
                if (productImages.Count > 0)
                {
                    foreach(var image in productImages)
                    {
                        var productImage =await _alishaMartContext.ProductImages.FindAsync(image.Id);
                        _alishaMartContext.ProductImages.Remove(productImage);
                    }
                }
                _alishaMartContext.Products.Remove(product);
                await _alishaMartContext.SaveChangesAsync();

                return "Product removed successfully.";
            }

            return "Something went wrong.";
        }
    }
}
