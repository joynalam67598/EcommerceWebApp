﻿using EcommerceWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public interface ICategoryRepository
    {
        int AddCategory(CategoryModel categoryModel);

        Task<List<CategoryModel>> GetAllCategories();
    }
}