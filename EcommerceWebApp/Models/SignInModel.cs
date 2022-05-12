using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApp.Models
{
    public class SignInModel
    {

        [Required(ErrorMessage = "Please, enter user email!")]
        [EmailAddress(ErrorMessage = "Please, enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
