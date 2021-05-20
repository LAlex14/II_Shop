using II_Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace II_Shop.Data {
    public class DbObjects {
        public static void Initial(AppDbContent content) {

            if(!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if(content.ShopCartItem.Any())
                content.ShopCartItem.RemoveRange(content.ShopCartItem.ToList());

            if (!content.Car.Any()) {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDesc = "Luxury Large",
                        LongDesc = "The most recognizable models on the road and part of history for making electric cars viable.",
                        Img = "/img/ModelS.jpg",
                        Price = 69420,
                        IsFavourite = true,
                        Stock = 20,
                        Category = Categories["Electric Car"]
                    },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDesc = "Small Hatchback",
                        LongDesc = "A small car that struggled to find a crowd with low gas prices and rising competition.",
                        Img = "/img/Fiesta.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        Stock = 19,
                        Category = Categories["Gasoline Car"]
                    },
                    new Car
                    {
                        Name = "BMW 3-Series",
                        ShortDesc = "Sport Small Sedan",
                        LongDesc = "It’s a compact luxury sedan that's been part of the automaker's lineup for more than 30 years.",
                        Img = "/img/M3.jpg",
                        Price = 41250,
                        IsFavourite = true,
                        Stock = 16,
                        Category = Categories["Gasoline Car"]
                    },
                    new Car
                    {
                        Name = "Mercedes C-Class",
                        ShortDesc = "Luxury Small Sedan",
                        LongDesc = "The 2021 C-Class should be at the top of your compact luxury sedan shopping list.",
                        Img = "/img/CClass.jpg",
                        Price = 41600,
                        IsFavourite = false,
                        Stock = 13,
                        Category = Categories["Gasoline Car"]
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDesc = "Small Hatchback",
                        LongDesc = "It was the first mass-market electric car to be sold in the United States.",
                        Img = "/img/Leaf.jpg",
                        Price = 14000,
                        IsFavourite = false,
                        Stock = 10,
                        Category = Categories["Electric Car"]
                    },
                    new Car
                    {
                        Name = "Porsche Taycan",
                        ShortDesc = "Luxury Mid-Size",
                        LongDesc = "It’s the performance-car brand’s first four-door sedan and first fully electric car.",
                        Img = "/img/Taycan.jpg",
                        Price = 79900,
                        IsFavourite = true,
                        Stock = 19,
                        Category = Categories["Electric Car"]
                    },
                    new Car
                    {
                        Name = "Volvo S60",
                        ShortDesc = "Mid-Size",
                        LongDesc = "It’s a mid-size sporty luxury sedan that directly competes with a trio of German models.",
                        Img = "/img/S60.jpg",
                        Price = 38950,
                        IsFavourite = false,
                        Stock = 12,
                        Category = Categories["Gasoline Car"]
                    },
                    new Car
                    {
                        Name = "Kia K5",
                        ShortDesc = "Mid-Size",
                        LongDesc = "Has all we’d want in a mid-size sedan, and it comes with a higher grade of materials.",
                        Img = "/img/K5.jpg",
                        Price = 23590,
                        IsFavourite = false,
                        Stock = 8,
                        Category = Categories["Gasoline Car"]
                    },
                    new Car
                    {
                        Name = "Porsche 911",
                        ShortDesc = "Best Coupe",
                        LongDesc = "The Porsche 911 is a two-seat sports car that's instantly recognizable as one of the world's best.",
                        Img = "/img/911.jpg",
                        Price = 99200,
                        IsFavourite = true,
                        Stock = 9,
                        Category = Categories["Gasoline Car"]
                    },
                    new Car
                    {
                        Name = "Audi A7",
                        ShortDesc = "Mid-Size Hatchback",
                        LongDesc = "A car with a beautiful sloped profile, that heaps luxury into a svelte shape like a great tuxedo.",
                        Img = "/img/A7.jpg",
                        Price = 69200,
                        IsFavourite = true,
                        Stock = 4,
                        Category = Categories["Gasoline Car"]
                    },
                    new Car
                    {
                        Name = "Jaguar I-Pace",
                        ShortDesc = "Svelte Crossover",
                        LongDesc = "Merges the powertrain technology of the future with everything expected in a prestige luxury.",
                        Img = "/img/IPace.jpg",
                        Price = 71490,
                        IsFavourite = false,
                        Stock = 15,
                        Category = Categories["Electric Car"]
                    },
                    new Car
                    {
                        Name = "Audi E-Tron",
                        ShortDesc = "SUV and Sportback",
                        LongDesc = "All the comfort, luxury, and features of Audi’s other premium models, with a fully electric twist.",
                        Img = "/img/ETron.jpg",
                        Price = 65900,
                        IsFavourite = false,
                        Stock = 10,
                        Category = Categories["Electric Car"]
                    },
                    new Car
                    {
                        Name = "Tesla Model X",
                        ShortDesc = "Large Hatchback",
                        LongDesc = "A fully electric vehicle that's more of a crossover than a true SUV and based on the Tesla Model S.",
                        Img = "/img/ModelX.jpg",
                        Price = 83700,
                        IsFavourite = true,
                        Stock = 11,
                        Category = Categories["Electric Car"]
                    },
                    new Car
                    {
                        Name = "Mercedes-Benz G Class",
                        ShortDesc = "Luxury Large SUV",
                        LongDesc = "The G-Class SUV is both an off-road and a luxury icon. It's roomy, trucky, and expensive.",
                        Img = "/img/GClass.jpg",
                        Price = 131400,
                        IsFavourite = true,
                        Stock = 14,
                        Category = Categories["Gasoline Car"]
                    },
                    new Car
                    {
                        Name = "Toyota Land Cruiser",
                        ShortDesc = "Luxury Large SUV",
                        LongDesc = "A luxury four-wheel drive vehicle produced by the Japanese automobile manufacturer Toyota.",
                        Img = "/img/LandCruiser.jpg",
                        Price = 85665,
                        IsFavourite = true,
                        Stock = 6,
                        Category = Categories["Gasoline Car"]
                    }
                    ); 
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories {
            get {
                if(category == null) {
                    var list = new Category[]
                    {
                        new Category {
                        CategoryName = "Electric Car",
                        Desc = "Car which is propelled by one or more electric motors, using energy stored in rechargeable batteries."},
                        new Category {
                        CategoryName = "Gasoline Car",
                        Desc = "Car which is propelled by one internal combustion engine, using different types of fuel."}
                    };
                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }
        }
    }
}
