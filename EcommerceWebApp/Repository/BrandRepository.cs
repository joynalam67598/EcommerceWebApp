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

        public async Task<BrandModel> GetBrand(int brandId)
        {
            return await _alishaMartContext.Brands.Where(brand => brand.Id == brandId)
                .Select(brand => new BrandModel()
                {
                    Id = brand.Id,
                    BrandName = brand.BrandName
                }).FirstOrDefaultAsync();
        }
        public async Task<int> UpdateBrand(BrandModel updatedBrand)
        {
            var brand = await _alishaMartContext.Brands.FindAsync(updatedBrand.Id);
            brand.BrandName = updatedBrand.BrandName;
            await _alishaMartContext.SaveChangesAsync();
            return brand.Id;
        }

        public async Task<int> DeleteBrand(int brandId)
        {
            var brand = await _alishaMartContext.Brands.FindAsync(brandId);
            _alishaMartContext.Brands.Remove(brand);
            await _alishaMartContext.SaveChangesAsync();
            return 1;
        }
    }
}
