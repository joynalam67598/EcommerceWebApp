﻿using EcommerceWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public interface IProductRepository
    {
        Task<int> AddProduct(ProductModel productModel);
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductDetails(int productId);
        Task<int> UpdateProduct(ProductImageModel updatedProduct);
    }
}