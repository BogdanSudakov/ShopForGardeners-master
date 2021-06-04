using Microsoft.AspNetCore.Mvc;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using ShopForGardeners.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IItems _itemRep;

        private readonly ShopCart _shopcart;

        public ShopCartController(IItems itemRep, ShopCart shopCart)
        {
            _itemRep = itemRep;
            _shopcart = shopCart;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "basket";

            var items = _shopcart.getShopCartItems();
            _shopcart.listShopItems = items;

            

            var obj = new ShopCartViewModel
            {
                shopCart = _shopcart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _itemRep.AllGardeningItems.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                _shopcart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult deleteToItem(int id)
        {
            var item = _shopcart.getShopCartItem(id);

            if (item != null)
            {
                _shopcart.DeleteToItem(item);
            }
            return RedirectToAction("Index");
        }

    }
}
