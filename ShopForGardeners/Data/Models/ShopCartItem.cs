using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public GardeningItem Item { get; set; }
        public double Price { get; set; }
        public string ShopCartId { get; set; }


    }
}
