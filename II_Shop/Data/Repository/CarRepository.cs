using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace II_Shop.Data.Repository {
    public class CarRepository: IAllCars {
        private readonly AppDbContent appDbContent; // for work with AppDbContent.cs
        public CarRepository(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Car> Cars => appDbContent.Car.Include(c => c.Category);
        public IEnumerable<Car> GetFavCars => appDbContent.Car.Where(p => p.IsFavourite && p.Stock > 0).Include(c => c.Category);
        public Car GetObjectCar(int carId) => appDbContent.Car.FirstOrDefault(p => p.Id == carId);
    }
}
