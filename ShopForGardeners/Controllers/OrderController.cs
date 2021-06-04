using Microsoft.AspNetCore.Mvc;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders orders;
        private readonly ShopCart shopCart;

        public OrderController(IOrders orders, ShopCart shopCart)
        {
            this.orders = orders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItems = shopCart.getShopCartItems();

            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("order", "you must have goods");
                ViewBag.Message = "you must have goods";
            }

            if (ModelState.IsValid)
            {
                orders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public ViewResult Complete()
        {
            ViewBag.Message = "order processed successfully";
            return View();
        }

    }
}
