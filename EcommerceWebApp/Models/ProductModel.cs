using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Display(Name = "Brand")]
        [Required]
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        [Required(ErrorMessage = "Please, enter the name of your product.")]
        [StringLength(100, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please, enter the name of your product.")]
        [StringLength(7)]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Please, enter the quantity of your product")]
        public int AvailableQuantity { get; set; }

        [Required(ErrorMessage = "Please, enter the buying price of your product")]
        public double BuyingPrice { get; set; }

        [Required(ErrorMessage = "Please, enter the selling price of your product")]
        public double SellingPrice { get; set; }
        public bool Status { get; set; }

        [Required(ErrorMessage = "Please, enter the description of your product")]
        [StringLength(2000, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public DateTime StockInDate { get; set; }

        [Display(Name = "Cover Photo")]
        public IFormFile CoverImage { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Gellary Photos")]
        public IFormFileCollection ProductImages { get; set; }

        public List<ProductImageModel> ProductImage { get; set; }



    }
}
