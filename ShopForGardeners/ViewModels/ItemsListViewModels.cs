using ShopForGardeners.Data.Models;
using System.Collections.Generic;

namespace ShopForGardeners.ViewModels
{
    public class ItemsListViewModels
    {
        //получение всех товаров
        public IEnumerable<GardeningItem> GetAllItems { get; set; }
        //получение категории
        public string CurrCategory { get; set; }
    }
}
