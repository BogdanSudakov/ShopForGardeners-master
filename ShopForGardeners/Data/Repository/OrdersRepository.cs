using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopForGardeners.Data.Repository
{
    public class OrdersRepository : IOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;

        }

        public IEnumerable<Order> GetAllOrders => appDBContent.Order;

        public void createOrder(Order order)
        {

            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);




            var items = shopCart.listShopItems;


            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ItemID = el.Item.Id,
                    OrderID = GetAllOrders?.Last().id + 1 ?? 7,
                    Price = el.Item.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }

    }
}
