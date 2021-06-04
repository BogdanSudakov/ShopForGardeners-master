using ShopForGardeners.Data.Models;
using System.Collections.Generic;

namespace ShopForGardeners.Data.Interfaces
{
    public interface IOrders
    {
        public IEnumerable<Order> GetAllOrders { get; }
        void createOrder(Order order);

    }
}
