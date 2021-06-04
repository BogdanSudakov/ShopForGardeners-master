using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }

        public int OrderID { get; set; }

        public int ItemID { get; set; }

        public double Price { get; set; }

        public virtual GardeningItem Item { get; set; }

        public virtual Order Order { get; set; }



    }
}
