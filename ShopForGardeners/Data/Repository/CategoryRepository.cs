using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using System.Collections.Generic;

namespace ShopForGardeners.Data.Repository
{
    public class CategoryRepository : IItemsCategory
    {
        private readonly AppDBContent _appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }


        public IEnumerable<Category> AllCategories => _appDBContent.AllCategories;
    }
}
