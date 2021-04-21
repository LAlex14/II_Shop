using II_Shop.Data.Models;
using System.Collections.Generic;

namespace II_Shop.ViewModels {
    public class CarsListViewModel {
        public IEnumerable<Car> allCars { get; set; }
        public string CurrCategory { get; set; }
    }
}
