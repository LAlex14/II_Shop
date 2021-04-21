using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using II_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace II_Shop.Controllers {
    public class CarsController: Controller {
        private readonly IAllCars _allCars; // variable for interfaces
        private readonly ICarsCategory _allCategories;

        // Constructor to read elements from interfaces
        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat) {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }


        [Route("Cars/List")]
        [Route("Cars/List/{category}")]

        // Funtion that return ViewResult
        public ViewResult List(string category) {

            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if(string.IsNullOrEmpty(category)) {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            } else {
                if(string.Equals("electric", category, System.StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Electric Car")).OrderBy(i => i.Id);
                    currCategory = "Electric Cars:";
                } else if(string.Equals("gasoline", category, System.StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Gasoline Car")).OrderBy(i => i.Id);
                    currCategory = "Gasoline Cars:";
                }

            }

            var carObj = new CarsListViewModel {
                allCars = cars,
                CurrCategory = currCategory
            };

            ViewBag.Title = "Page with cars";
            return View(carObj);
        }

    }
}