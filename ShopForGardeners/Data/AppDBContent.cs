using Microsoft.EntityFrameworkCore;
using ShopForGardeners.Data.Models;

namespace ShopForGardeners.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<GardeningItem> AllItems { get; set; }

        public DbSet<Category> AllCategories { get; set; }

        public DbSet<ShopCartItem> ShopCartItem { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<User> User { get; set; }
    }
}
