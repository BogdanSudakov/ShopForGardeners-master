using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopForGardeners.Data.Mocks
{
    public class MockItem : IItems
    {
        readonly IItemsCategory _itemsCategory = new MockCategory();
        public IEnumerable<GardeningItem> AllGardeningItems
        {
            get
            {
                return new List<GardeningItem>
                {
                    new GardeningItem{Name="onion",
                        ShortDesc="Up to 5 Inches in Diameter",
                        LongDesc="Purportedly the best white onion in the long day category, Ringmaster White Sweet Spanish Onion gives gardeners a large globe with single centers and a firm, mild flesh. Ringmaster also stores well and can be grown in short day areas for early green onions. Favorite choice for onion rings!",
                        Img="/img/onion.jpg",
                        Price=0.2,
                        IsFavourite=true,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Seed")  },

                    new GardeningItem{Name="lily",
                        ShortDesc="Mid to late summer blooming; Easy to grow",
                        LongDesc="Double Tiger Lily",
                        Img="/img/lily.jpg",
                        Price=0.3,
                        IsFavourite=true,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Seed")  },

                    new GardeningItem{Name="lilies of the valley",
                        ShortDesc="Early to Mid Summer Blooming, Easy to Grow",
                        LongDesc="Asiatic Lily Bulbs - Mixed Colors - Spring Planted Lilies",
                        Img="/img/lilies of the valley.jpg",
                        Price=0.5,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Seed")  },

                    new GardeningItem{Name="tomato",
                        ShortDesc="Prefers full sun exposure",
                        LongDesc="Grow Heirloom Tomatoes - Plant Atkinson Tomato Seeds",
                        Img="/img/tomato.jpg",
                        Price=0.2,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Seed")  },

                    new GardeningItem{Name="cucumber",
                        ShortDesc="65 Days to Harvest",
                        LongDesc="The Ashley Cucumber is an excellent slicing cucumber that is perfect for salads. Plant Ashley Cucumber seeds in either sun or partial shade and enjoy high yields and a delicious taste. Ashley cucumbers are ideal cucumbers for humid areas as they are resistant to downy mildew.",
                        Img="/img/cucumber.jpg",
                        Price=0.2,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Seed")  },

                    new GardeningItem{Name="potato",
                        ShortDesc="Great Tasting Beefsteak",
                        LongDesc="Fresh Potato",
                        Img="/img/potato.jpg",
                        Price=0.5,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Seed")  },

                    new GardeningItem{Name="Spruce",
                        ShortDesc="Blue Teardrop Spruce",
                        LongDesc="The Blue Teardrop Spruce is a small conifer growing to about 4 feet tall and 2 feet wide within 10 years, and taller with time.",
                        Img="/img/Spruce.jpg",
                        Price=1,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Seed")  },

                    new GardeningItem{Name="Juniper",
                        ShortDesc="Blue Arrow Juniper",
                        LongDesc="The Blue Arrow Juniper is a wonderful narrow accent plant, reaching 10 or 12 feet tall, while staying no more than 2 feet wide.",
                        Img="/img/Blue Arrow Juniper.jpg",
                        Price=1.5,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Seed")  },

                    new GardeningItem{Name="Canna Terra Professional Soil Mix Bag 50L",
                        ShortDesc="by CANNA",
                        LongDesc="Very good soil. I planted up two large pots , one with this and the other with a well known brand and the plant in this Canna one is looking a lot healthier and has grown quite a bit larger than the other one. It may have cost nearly twice as much as the other one but the results are well worth it ,I would definitely buy this again.",
                        Img="/img/Canna Terra Professional Soil Mix Bag 50L.jpg",
                        Price=5,
                        IsFavourite=true,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Soil")  },

                    new GardeningItem{Name="Miracle-Gro All Purpose Enriched Compost 50L",
                        ShortDesc="by Miracle-Gro",
                        LongDesc="As a Prime customer, I ordered six bags (delivery free) and it arrived the next morning. - The compost is exceptional quality with added plant nutrients too. - I'd been buying 'cheap' stuff from the local supermarket, which cost twice as much!",
                        Img="/img/Miracle-Gro All Purpose Enriched Compost 50L.jpg",
                        Price=4,
                        IsFavourite=true,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Soil")  },

                    new GardeningItem{Name="Miracle-Gro Potting Mix - 8 Litre",
                        ShortDesc="by Miracle-Gro",
                        LongDesc="If an amateur like me can grow with this anyone can! - by Lynds Fantastic potting mix only had anything grow with this...i recommend",
                        Img="/img/Miracle-Gro Potting Mix - 8 Litre.jpg",
                        Price=1,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Soil")  },

                    new GardeningItem{Name="BioBizz 50L Light-Mix Potting Soil Bag",
                        ShortDesc="by BioBizz",
                        LongDesc="\"Five Stars\" - by Chris I swear by this soil ! Gives the grower complete control",
                        Img="/img/BioBizz 50L Light-Mix Potting Soil Bag.jpg",
                        Price=4.50,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Soil")  },

                    new GardeningItem{Name="Westland Houseplant Potting Compost Mix and Enriched with Seramis, 4 L",
                        ShortDesc="by Westland",
                        LongDesc="\"My plants are happy and so am I!\" - by Ness (England) I had never re-potted an orchid before. This compost was easy to use. There is plenty of it - I moved two orchids into 16cm pots and there is at least enough left for another 2.Both plants are still thriving after a number of weeks.",
                        Img="/img/Westland Houseplant Potting Compost Mix and Enriched with Seramis, 4 L.jpg",
                        Price=0.8,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Soil")  },

                    new GardeningItem{Name="Black Magic Potting Mix 20L Compost, Black, 20 L",
                        ShortDesc="by Black Magic",
                        LongDesc="\"Magic product\" - by JulesSA This soil is amazing! All my plants are flourishing beautifully since planted into this soil. It's a no brainer - excellent value!",
                        Img="/img/Black Magic Potting Mix 20L Compost, Black, 20 L.jpg",
                        Price=2,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Soil")  },

                    new GardeningItem{Name="Miracle-Gro All Purpose Enriched Compost 50L **ENRICHED WITH MIRACLE GRO PLANT FOOD",
                        ShortDesc="by Miracle-Gro",
                        LongDesc="\"Flowers\" - by mrs valerie mason Plants love this compost no need to feed pay a little more it's worth the money",
                        Img="/img/Miracle-Gro All Purpose Enriched Compost 50LENRICHED WITH MIRACLE GRO PLANT FOOD.jpg",
                        Price=5,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Soil")  },

                    new GardeningItem{Name="Professional Compost Bag 80L for all potting needs",
                        ShortDesc="by YouGarden",
                        LongDesc="\"Great stuff\" - by Chrissie I'm a novice gardener and this is by far the best compost I've used. Soft and fluffy and worked wonder on my veg. Would 100% buy again.",
                        Img="/img/Professional Compost Bag 80L for all potting needs.jpg",
                        Price=9,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Soil")  },

                    new GardeningItem{Name="Gardener’s Pro Pruner #2",
                        ShortDesc="Comfort grip handles help prevent wrist fatigue",
                        LongDesc="Snip with confidence with our exclusive bypass pruners. Blades are long-wearing, with wire-cutting notch and sap groove. Lightweight, forged aluminum handles are coated with a non-slip comfort grip to keep them firmly in your hand and reduce fatigue. Superior quality you can count on!",
                        Img="/img/Gardener’s Pro Pruner #2.jpg",
                        Price=15,
                        IsFavourite=true,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Garden tool")  },

                    new GardeningItem{Name="Pocket Snips",
                        ShortDesc="Compact snips make precise cuts",
                        LongDesc="Our staff gardeners love these compact snips. The ergonomic, non-slip grip and narrow, super-sharp blades let you make precision cuts without damaging nearby stems. ",
                        Img="/img/Pocket Snips.jpg",
                        Price=14,
                        IsFavourite=true,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Garden tool")  },

                    new GardeningItem{Name="Gardener’s Lifetime Raised Bed Cultivator",
                        ShortDesc="This tool comes with our exclusive lifetime guarantee",
                        LongDesc="Get two favorite tools in one — a swan-neck hoe on one side and a three-prong cultivator on the other. This cultivator has an 18 wooden handle, making it perfect for loosening and smoothing soil in raised beds. ",
                        Img="/img/Gardener’s Lifetime Raised Bed Cultivator.jpg",
                        Price=20,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Garden tool")  },

                    new GardeningItem{Name="Gardener’s Lifetime Half-Moon Hoe",
                        ShortDesc="Long-handled hoe has a sharp edge for slicing just below the soil surface",
                        LongDesc="Also called a swan-neck hoe, this popular tool cuts weeds just below the soil surface.",
                        Img="/img/Gardener’s Lifetime Half-Moon Hoe.jpg",
                        Price=10,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Garden tool")  },

                    new GardeningItem{Name="Mod Hod",
                        ShortDesc="Carry, organize and store — in every season, for every reason!",
                        LongDesc="The name says it all! Our exclusive Mod Hod is a modern take on the traditional harvesting hod.",
                        Img="/img/Mod Hod.jpg",
                        Price=10.99,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Garden tool")  },

                    new GardeningItem{Name="Gardener’s Puddle-Proof Tote",
                        ShortDesc="Keeps hand tools and supplies easy to carry and right by your side",
                        LongDesc="This convenient tote is the perfect grab-and-go bag for a quick weeding session or a full day in the garden.",
                        Img="/img/Gardener’s Puddle-Proof Tote.jpg",
                        Price=12.50,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Garden tool")  },

                    new GardeningItem{Name="Garden Hods",
                        ShortDesc="Mesh bottom lets you easily rinse and drain produce",
                        LongDesc="Originally used by Maine clam diggers to hold and rinse their catch, these hods are popular gathering baskets for the garden harvest and cut flowers. ",
                        Img="/img/Garden Hods.jpg",
                        Price=7,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Garden tool")  },

                    new GardeningItem{Name="Mini Mod Hod",
                        ShortDesc="Smooth perforated interior is gentle on produce",
                        LongDesc="Indispensable, hard-working mini-version of our popular Mod Hod, this gardening basket is one of our favorites! Great for gathering and washing crops right in the garden (no more mud in the kitchen sink!) ",
                        Img="/img/Mini Mod Hod.jpg",
                        Price=7.50,
                        IsFavourite=false,
                        Available=true,
                        Category=_itemsCategory.AllCategories.Single(c => c.CategoryName == "Garden tool")  }

                };
            }
        }

        public IEnumerable<GardeningItem> GetFavItems => throw new NotImplementedException();

        public GardeningItem GetObjectItem(int ItemId)
        {
            throw new NotImplementedException();
        }
    }
}
