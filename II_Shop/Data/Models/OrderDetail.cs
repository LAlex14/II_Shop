namespace II_Shop.Data.Models {
    public class OrderDetail {
        public int id { get; set; }
        public int orderId { get; set; }
        public int CarId { get; set; }
        public uint price { get; set; }
        public virtual Car car { get; set; }
        public virtual Order order { get; set; }
    }
}
