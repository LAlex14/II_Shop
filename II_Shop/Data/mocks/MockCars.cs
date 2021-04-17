using System.Collections.Generic;
using System.Linq;
using II_Shop.Data.interfaces;
using II_Shop.Data.Models;

namespace II_Shop.Data.mocks {
    public class MockCars : IAllCars {

        private readonly ICarsCategory _categoryCars = new MockCategory();
        
        public IEnumerable<Car> Cars {
            get {
                return new List<Car> {
                    new Car {
                        Name = "Tesla Model S",
                        ShortDesc = "An all-electric five-door liftback sedan",
                        LongDesc = "Tesla cars are high performance. The Model S can cruise for over 400 miles on a full charge, and recharging is a user-friendly task.",
                        Img = "https://tesla-cdn.thron.com/delivery/public/image/tesla/56cb8c41-e898-44ce-b6b7-fe9b9a05f529/bvlatuR/std/1200x628/MS-Social",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        Name = "Ford Fiesta",
                        ShortDesc = "Fiesta is a supermini marketed by Ford",
                        LongDesc = "Comfortable little car for city life.The name Fiesta (meaning 'party' in Spanish).",
                        Img = "https://carmag.co.za/upload/articles/2020/06/fiesta-48v.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        Name = "BMW M3",
                        ShortDesc = "BMW M3 is fast and beautiful car.",
                        LongDesc = "The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW's in-house motorsport division, BMW M GmbH. ",
                        Img = "https://autoblog.md/media/2020/09/New-BMW-M3-M4-leak-photos_4.jpg",
                        Price = 65000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        Name = "Mercedes C Class",
                        ShortDesc = "Compact luxury car.",
                        LongDesc = "The Mercedes-Benz C-Class is a line of compact executive cars produced by Daimler AG.",
                        Img = "https://aczpix.b-cdn.net/wp-content/uploads/2021/02/foto-c-class-w206_01.jpg",
                        Price = 40000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        Name = "Nissan Leaf",
                        ShortDesc = "Compact five-door hatchback.",
                        LongDesc = "Nissan LEAF is a pure electric vehicle powered only by electricity, and its battery can be charged at home.",
                        Img = "https://upload.wikimedia.org/wikipedia/commons/d/de/Nissan_Leaf_2018_%2831874639158%29_%28cropped%29.jpg",
                        Price = 14000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    },

                };
            }
        }

        public IEnumerable<Car> GetFavCars { get; set; }
        public Car GetObjectCar(int carId) {
            throw new System.NotImplementedException();
        }
    }
}