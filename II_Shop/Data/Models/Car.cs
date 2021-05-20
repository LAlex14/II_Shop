namespace II_Shop.Data.Models {
    public class Car {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortDesc { set; get; }
        public string LongDesc { set; get; }
        public string Img { set; get; }
        public int Price { set; get; }
        public bool IsFavourite { set; get; }
        public int Stock { set; get; }
        public int CategoryId { set; get; }
        public virtual Category Category { set; get; }
        public bool Available {
            get { return Stock > 0; }
        }
    }
}