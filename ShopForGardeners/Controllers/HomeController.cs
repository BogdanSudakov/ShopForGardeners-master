using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.ViewModels;

namespace ShopForGardeners.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItems _itemRep;

        public HomeController(IItems itemRep)
        {
            _itemRep = itemRep;

        }
        [Authorize]
        public ViewResult Index()
        {
            ViewBag.Title = "start page";
            ViewBag.Login = User.Identity.Name;
            var HomeCars = new HomeViewModel
            {
                favItems = _itemRep.GetFavItems
            };
            return View(HomeCars);
        }



    }
}
