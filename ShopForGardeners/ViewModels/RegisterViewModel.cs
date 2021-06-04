using System.ComponentModel.DataAnnotations;

namespace ShopForGardeners.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Enter your Email")]
        [StringLength(50, ErrorMessage = "the field should be no more than 50 characters")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The field must be filled")]
        public string Email { get; set; }

        [Display(Name = "Enter your Login")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Line length must be between 5 and 50 characters")]
        [Required(ErrorMessage = "The field must be filled")]
        public string Login { get; set; }

        [Display(Name = "Enter your Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Line length must be between 2 and 50 characters")]
        [Required(ErrorMessage = "The field must be filled")]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Line length must be between 6 and 100 characters")]
        [Required(ErrorMessage = "The field must be filled")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }




    }
}
