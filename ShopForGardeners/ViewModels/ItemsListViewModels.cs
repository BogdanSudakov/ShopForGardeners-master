using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
