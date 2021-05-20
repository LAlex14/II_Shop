using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using II_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace II_Shop.Controllers {
    public class ShopCartController: Controller {
        private IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart) {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index() {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj1 = new ShopCartViewModel {
                shopCart = _shopCart
            };
            return View(obj1);
        }
        public RedirectToActionResult Add(int id) {
            var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
            if(item != null) {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id) {
            var item = _shopCart.getShopItems().FirstOrDefault(i => i.Id == id);
            if(item != null) {
                _shopCart.DeleteFromCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
