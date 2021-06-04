using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Interfaces
{
   public interface IItems
    {
        //получение всех товаров
        IEnumerable<GardeningItem> AllGardeningItems { get;  }
        //получение популярных товаров
        IEnumerable<GardeningItem> GetFavItems { get; }
        //получение 1 товара
        GardeningItem GetObjectItem(int ItemId);

    }
}
