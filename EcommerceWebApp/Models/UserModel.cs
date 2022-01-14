using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Models
{
    public class UserModel
    {
        [Required(ErrorMessage ="Please, enter user name!")]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter user name!")]
        [DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }
        [Required(ErrorMessage = "Please, enter user email!")]
        [EmailAddress(ErrorMessage ="Please, enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, enter user birth date!")]
        [DataType(DataType.Date)]
        public DateTime  BirthDate{ get; set; }

        [Required(ErrorMessage = "Please, select user role!")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Please, enter user address!")]
        [MinLength(5)]
        public string Address { get; set; }


    }
}
