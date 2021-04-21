namespace II_Shop.Data.Models {
    public class Car {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortDesc { set; get; }
        public string LongDesc { set; get; }
        public string Img { set; get; }
        public ushort Price { set; get; }
        public bool IsFavourite { set; get; }
        public bool Available { set; get; }
        public int CategoryId { set; get; }
        public virtual Category Category { set; get; }
    }
}