using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Data
{
    public class Products
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int AvailableQuantity { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime? StockInDate { get; set; }

        public string CoverImageUrl { get; set; }
        public Categories Category { get; set; }
        public Brands Brand { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; }

    }
}
