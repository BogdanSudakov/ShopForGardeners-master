using ShopForGardeners.Data.Models;
using System.Collections.Generic;

namespace ShopForGardeners.Data.Interfaces
{
    public interface IItems
    {
        //получение всех товаров
        IEnumerable<GardeningItem> AllGardeningItems { get; }
        //получение популярных товаров
        IEnumerable<GardeningItem> GetFavItems { get; }
        //получение 1 товара
        GardeningItem GetObjectItem(int ItemId);

    }
}
