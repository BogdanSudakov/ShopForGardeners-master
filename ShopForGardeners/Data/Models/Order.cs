using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Required(ErrorMessage = "The field must be filled")]
        [Display(Name = "Enter your name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Line length must be between 3 and 30 characters")]

        public string Name { get; set; }

        [Display(Name = "Enter your surname")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "Line length must be between 3 and 35 characters")]
        [Required(ErrorMessage = "The field must be filled")]

        public string Surname { get; set; }

        [Display(Name = "Enter your adress")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Line length must be between 3 and 50 characters")]
        [Required(ErrorMessage = "The field must be filled")]

        public string Adress { get; set; }

        [Display(Name = "Enter your phone number")]
        [StringLength(30,MinimumLength = 7, ErrorMessage = "Line length must be between 7 and 30 characters")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The field must be filled")]


        public string Phone { get; set; }

        [Display(Name = "Enter your Email")]
        [StringLength(50, ErrorMessage = "the field should be no more than 50 characters")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The field must be filled")]
        public string Email { get; set; }

        [BindNever]       
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }









    }
}
