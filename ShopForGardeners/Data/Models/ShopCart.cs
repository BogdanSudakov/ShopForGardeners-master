using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopForGardeners.Data.Models
{
    public class ShopCart
    {
        AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            //CartId (key)
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };

        }

        public void AddToCart(GardeningItem item)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Item = item,
                Price = item.Price
            });

            appDBContent.SaveChanges();
        }
        public void DeleteToItem(ShopCartItem Item)
        {
            var item = Item;
            appDBContent.ShopCartItem.Remove(item);

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopCartItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Item).ToList();
        }

        public ShopCartItem getShopCartItem(int id)
        {
            return appDBContent.ShopCartItem.First(c => c.ShopCartId == ShopCartId && c.Item.Id == id);
        }


    }
}
