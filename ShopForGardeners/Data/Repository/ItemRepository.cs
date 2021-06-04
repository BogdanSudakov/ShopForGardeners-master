using Microsoft.EntityFrameworkCore;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Repository
{
    public class ItemRepository : IItems
    {
        private readonly AppDBContent _appDBContent;

        public ItemRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public IEnumerable<GardeningItem> AllGardeningItems => _appDBContent.AllItems.Include(c => c.Category);

        public IEnumerable<GardeningItem> GetFavItems => _appDBContent.AllItems.Where(c => c.IsFavourite).Include(c => c.Category);

        public GardeningItem GetObjectItem(int ItemId) => _appDBContent.AllItems.FirstOrDefault(c => c.Id == ItemId);
        
    }
}
