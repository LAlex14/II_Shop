using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using System.Collections.Generic;

namespace II_Shop.Data.Repository {
    public class CategoryRepository: ICarsCategory {

        private readonly AppDbContent appDbContent;
        public CategoryRepository(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => appDbContent.Category;
    }
}
