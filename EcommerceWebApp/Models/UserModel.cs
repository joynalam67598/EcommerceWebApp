using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Models
{
    public class UserModel
    {
        [Required(ErrorMessage ="Please, enter user first name!")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, enter user name!")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please, enter user email!")]
        [EmailAddress(ErrorMessage ="Please, enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter password!")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword",ErrorMessage ="Password dose not match")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, confirm your password!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please, enter user birth date!")]
        [DataType(DataType.Date)]
        [Display(Name="Birth Date")]
        public DateTime  BirthDate{ get; set; }

        [Required(ErrorMessage = "Please, enter city name!")]
        public string City { get; set; }

        public string Role { get; set; }

        [Required(ErrorMessage = "Please, enter user address!")]
        [MinLength(5)]
        public string Address { get; set; }


    }
}
