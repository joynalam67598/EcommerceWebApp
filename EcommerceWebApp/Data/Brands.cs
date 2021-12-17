using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Data
{
    public class Brands
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
