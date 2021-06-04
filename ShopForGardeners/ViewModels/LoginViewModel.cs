
using System.ComponentModel.DataAnnotations;


namespace ShopForGardeners.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "The Login must be filled")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The Password must be filled")]
        [DataType(DataType.Password)]
        public string Password { get; set; }






    }
}
