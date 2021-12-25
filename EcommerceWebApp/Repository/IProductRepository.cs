using EcommerceWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public interface IProductRepository
    {
        Task<string> AddProduct(ProductModel productModel);
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductDetails(int productId);
        Task<string> UpdateProduct(ProductModel updatedProduct);
        Task<string> DeleteProduct(int productId);
    }
}