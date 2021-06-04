namespace ShopForGardeners.Data.Models
{

    public class GardeningItem
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public string ShortDesc { set; get; }

        public string LongDesc { set; get; }

        public string Img { set; get; }

        public double Price { set; get; }

        public bool IsFavourite { set; get; }

        public bool Available { set; get; }

        public int CategoryID { set; get; }

        public virtual Category Category { get; set; }
    }
}
