using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Mocks
{
    public class MockCategory : IItemsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Seed",Desription="A seed is an embryonic plant enclosed in a protective outer covering"},
                    new Category{CategoryName="Soil",Desription="Soil is a mixture of organic matter, minerals, gases, liquids, and organisms that together support life"},
                    new Category{CategoryName="Garden tool",Desription="A garden tool is any one of many tools made for gardening and overlaps with the range of tools made for agriculture and horticulture"}
                };
            }
        }
    }
}
