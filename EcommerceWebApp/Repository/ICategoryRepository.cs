using EcommerceWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public interface ICategoryRepository
    {
        Task<int> AddCategory(CategoryModel categoryModel);

        Task<List<CategoryModel>> GetAllCategories();

        Task<CategoryModel> GetCategory(int categoryId);

        Task<int> UpdateCategory(CategoryModel updatedCategory);
        Task<int> DeleteCategory(int categroyId);
    }
}