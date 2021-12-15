using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
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

        public int AddCategory(CategoryModel categoryModel)
        {
            var newCategory = new Categories
            {
                CategoryName = categoryModel.CategoryName

            };
            _alishaMartContext.Add(newCategory);
            _alishaMartContext.SaveChanges();

            return newCategory.Id;
        }

    }
}
