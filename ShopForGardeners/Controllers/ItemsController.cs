using Microsoft.AspNetCore.Mvc;
using ShopForGardeners.Data;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using ShopForGardeners.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ShopForGardeners.Controllers
{
    //_ == readonly
    [Route("[controller]/[action]")]
    public class ItemsController : Controller
    {
        private readonly IItems _items;
        private readonly IItemsCategory _itemsCategory;
        private readonly AppDBContent content;

        public ItemsController(IItems _items, IItemsCategory _itemsCategory, AppDBContent appDBContent)
        {
            this._items = _items;
            this._itemsCategory = _itemsCategory;
            content = appDBContent;
            DBobjects.Initial(content);
            content.SaveChanges();
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            GardeningItem newObj = new GardeningItem
            {
                Name = "onion",
                ShortDesc = "Up to 5 Inches in Diameter",
                LongDesc = "Purportedly the best white onion in the long day category, Ringmaster White Sweet Spanish Onion gives gardeners a large globe with single centers and a firm, mild flesh. Ringmaster also stores well and can be grown in short day areas for early green onions. Favorite choice for onion rings!",
                Img = "/img/onion.jpg",
                Price = 0.2,
                IsFavourite = true,
                Available = true,
                CategoryID = 1
            };
            content.AllItems.Add(newObj);
            return Ok();
        }
        //[HttpGet]
        [HttpGet("{category?}")]
        public ViewResult List(string category)
        {
            ViewBag.Title = "All Items";

            string _category = category;
            IEnumerable<GardeningItem> items = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                items = _items.AllGardeningItems.OrderBy(i => i.Id);
                currCategory = "All items";
            }
            else
            {
                if (string.Equals("Seeds", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Seed")).OrderBy(i => i.Id);
                }
                else if (string.Equals("Soils", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Soil")).OrderBy(i => i.Id);
                }

                else if (string.Equals("tools", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Garden tool")).OrderBy(i => i.Id);
                }
                currCategory = _category;


            }

            var itemObj = new ItemsListViewModels
            {
                GetAllItems = items,
                CurrCategory = currCategory
            };


            //View(model)
            return View(itemObj);
        }

        [HttpGet("{category?}")]
        public IActionResult ListJson(string category)
        {
            ViewBag.Title = "All Items";

            string _category = category;
            IEnumerable<GardeningItem> items = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                items = _items.AllGardeningItems.OrderBy(i => i.Id);
                currCategory = "All items";
            }
            else
            {
                if (string.Equals("Seeds", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Seed")).OrderBy(i => i.Id);
                }
                else if (string.Equals("Soils", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Soil")).OrderBy(i => i.Id);
                }

                else if (string.Equals("tools", category, StringComparison.OrdinalIgnoreCase))
                {

                    items = _items.AllGardeningItems.Where(i => i.Category.CategoryName.Equals("Garden tool")).OrderBy(i => i.Id);
                }
                currCategory = _category;


            }

            var itemObj = new ItemsListViewModels
            {
                GetAllItems = items,
                CurrCategory = currCategory
            };

            var result = items
                .Select(e => e.Name)
                .ToList();

            //View(model)
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ViewResult MoreDetails(int id)
        {

            var items = _items.AllGardeningItems.FirstOrDefault(i => i.Id == id);
            if (items == null)
                items = _items.AllGardeningItems.First(i => i.Id == 1);

            return View(items);
        }

        public FileResult SaveCategories()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };

            var json = JsonSerializer.Serialize(_itemsCategory.AllCategories, options);
            System.IO.File.WriteAllText($"{Environment.CurrentDirectory}\\file.json", json);
            byte[] fileBytes = System.IO.File.ReadAllBytes($"{Environment.CurrentDirectory}\\file.json");
            string fileName = "Categories.json";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public FileResult SaveItems()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };

            var json = JsonSerializer.Serialize(content.AllItems, options);
            System.IO.File.WriteAllText($"{Environment.CurrentDirectory}\\file.json", json);
            byte[] fileBytes = System.IO.File.ReadAllBytes($"{Environment.CurrentDirectory}\\file.json");
            string fileName = "Items.json";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}