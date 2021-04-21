using II_Shop.Data.Models;
using System.Collections.Generic;

namespace II_Shop.Data.interfaces {
    public interface IAllCars {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavCars { get; }
        Car GetObjectCar(int carId);
    }
}