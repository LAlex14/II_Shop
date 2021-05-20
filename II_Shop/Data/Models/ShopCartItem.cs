namespace II_Shop.Data.Models {
    public class ShopCartItem {
        public int Id { get; set; }
        public Car car { get; set; }
        public int price { get; set; }
        public string ShopCartId { get; set; }
    }
}
