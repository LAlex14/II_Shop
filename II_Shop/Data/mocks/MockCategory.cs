using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using System.Collections.Generic;

namespace II_Shop.Data.mocks {
    public class MockCategory: ICarsCategory {
        public IEnumerable<Category> AllCategories {
            get {
                return new List<Category> {
                    new Category {
                        CategoryName = "Electric Cars",
                        Desc = "Car which is propelled by one or more electric motors, using energy stored in rechargeable batteries."},
                    new Category {
                        CategoryName = "Basic Cars",
                        Desc = "Car which is propelled by one internal combustion engine, using different types of fuel."}
                };
            }
        }
    }
}