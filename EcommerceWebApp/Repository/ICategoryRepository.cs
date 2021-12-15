using EcommerceWebApp.Models;

namespace EcommerceWebApp.Repository
{
    public interface ICategoryRepository
    {
        int AddCategory(CategoryModel categoryModel);
    }
}