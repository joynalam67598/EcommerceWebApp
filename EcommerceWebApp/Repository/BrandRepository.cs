using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AlishaMartContext _alishaMartContext = null;

        public BrandRepository(AlishaMartContext alishaMartContext)
        {
            _alishaMartContext = alishaMartContext;
        }

        public int AddBrand(BrandModel BrandModel)
        {
            var newBrand = new Brands
            {
                BrandName = BrandModel.BrandName

            };
            _alishaMartContext.Add(newBrand);
            _alishaMartContext.SaveChanges();

            return newBrand.Id;
        }

        public async Task<List<BrandModel>> GetAllBrands()
        {
            return await _alishaMartContext.Brands.Select(brand => new BrandModel()
            {
                Id = brand.Id,
                BrandName = brand.BrandName
            }).ToListAsync();
        }

    }
}
