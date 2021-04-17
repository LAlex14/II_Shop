using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing.Matching;
using II_Shop.Data.Models;

namespace II_Shop.ViewModels {
    public class CarsListViewModel {
        public IEnumerable<Car> allCars { get; set; }
        public string CurrCategory { get; set; }
    }
}
