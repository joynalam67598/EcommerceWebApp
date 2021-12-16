using EcommerceWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebApp.Repository
{
    public interface IBrandRepository
    {
        int AddBrand(BrandModel BrandModel);
        Task<List<BrandModel>> GetAllBrands();
    }
}