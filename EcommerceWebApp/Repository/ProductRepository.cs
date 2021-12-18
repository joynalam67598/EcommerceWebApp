using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public class ProductRepository
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

            foreach(var image in productModel.ProductImage)
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
    }
}
