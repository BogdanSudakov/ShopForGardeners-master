using System.Collections.Generic;

namespace ShopForGardeners.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Desription { get; set; }

        public List<GardeningItem> GardeningItems { get; set; }

    }
}
