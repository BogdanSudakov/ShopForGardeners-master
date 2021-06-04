using ShopForGardeners.Data.Models;
using System.Collections.Generic;

namespace ShopForGardeners.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<GardeningItem> favItems { get; set; }

    }
}
