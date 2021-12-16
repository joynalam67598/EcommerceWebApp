using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AlishaMartContext _alishaMartContext = null;

        public CategoryRepository(AlishaMartContext alishaMartContext)
        {
            _alishaMartContext = alishaMartContext;
        }

        public async Task<int> AddCategory(CategoryModel categoryModel)
        {
            var newCategory = new Categories
            {
                CategoryName = categoryModel.CategoryName

            };
            _alishaMartContext.Add(newCategory);
            await _alishaMartContext.SaveChangesAsync();

            return newCategory.Id;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return await _alishaMartContext.Categories.Select(category => new CategoryModel()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            }).ToListAsync();
        }

        public async Task<CategoryModel> GetCategory(int categoryId)
        {
            return await _alishaMartContext.Categories.Where(category => category.Id == categoryId)
                .Select(category => new CategoryModel()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateCategory(CategoryModel updatedCategory)
        {
            var category = await _alishaMartContext.Categories.FindAsync(updatedCategory.Id);
            category.CategoryName = updatedCategory.CategoryName;
            await _alishaMartContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task<int> DeleteCategory(int categroyId)
        {
            var category = await _alishaMartContext.Categories.FindAsync(categroyId);
            _alishaMartContext.Categories.Remove(category);
            await _alishaMartContext.SaveChangesAsync();
            return 1;
        }

    }
}
