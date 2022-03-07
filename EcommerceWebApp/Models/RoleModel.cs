using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Models
{
    public class RoleModel
    {
        public string RoleId { get; set; }
        [Required]
        public string RoleName { get; set;}

        public bool IsSelected { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<SelectListItem> ApplicationUserRole { get; set; }
    }
}
