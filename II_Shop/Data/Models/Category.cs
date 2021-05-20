using System.Collections.Generic;

namespace II_Shop.Data.Models {
    public class Category {
        public int Id { set; get; }
        public string CategoryName { set; get; }
        public string Desc { set; get; }
        public List<Car> Cars { set; get; }
    }
}