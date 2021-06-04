using System;
using System.ComponentModel.DataAnnotations;

namespace ShopForGardeners.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
       // public object ReturnUrl { get; internal set; }
    }
}