using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Models
{
    public class BrandModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter Brand name!")]
        [StringLength(30, MinimumLength = 3)]
        public string BrandName { get; set; }
    }
}
