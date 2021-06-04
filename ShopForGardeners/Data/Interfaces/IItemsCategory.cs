using ShopForGardeners.Data.Models;
using System.Collections.Generic;

namespace ShopForGardeners.Data.Interfaces
{
    public interface IItemsCategory
    {
        //получение всех категорий
        IEnumerable<Category> AllCategories { get; }
    }
}
