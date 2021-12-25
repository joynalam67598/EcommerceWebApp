using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Data
{
    public class ProductImages
    {
        public int Id { get; set; }

        public int ProductsId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Products Products { get; set; }
    }
}
