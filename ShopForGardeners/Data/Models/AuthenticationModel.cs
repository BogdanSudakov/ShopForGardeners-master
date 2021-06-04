using System;
using System.ComponentModel.DataAnnotations;

namespace ShopForGardeners.ViewModels
{
    public class AuthenticationModel
    {
        [Required]

        public string Verification { get; set; }
        public string ReturnUrl { get; set; } = "/";

    }
}