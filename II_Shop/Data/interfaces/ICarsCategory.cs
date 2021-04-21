using II_Shop.Data.Models;
using System.Collections.Generic;

namespace II_Shop.Data.interfaces {
    public interface ICarsCategory {
        IEnumerable<Category> AllCategories { get; }
    }
}