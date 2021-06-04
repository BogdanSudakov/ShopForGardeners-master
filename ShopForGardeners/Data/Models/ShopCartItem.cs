namespace ShopForGardeners.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public GardeningItem Item { get; set; }
        public double Price { get; set; }
        public string ShopCartId { get; set; }


    }
}
