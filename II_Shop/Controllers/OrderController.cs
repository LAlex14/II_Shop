using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace II_Shop.Controllers {
    public class OrderController: Controller {

        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart) {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout() {
            return View();
        }

        [HttpPost] // to work only after post method
        public IActionResult Checkout(Order order) {
            shopCart.listShopItems = shopCart.getShopItems();
            if(shopCart.listShopItems.Count == 0) {
                ModelState.AddModelError("", "You should add items to the cart");
            }

            if(ModelState.IsValid) {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete() {
            shopCart.DeleteAllFromCart();
            ViewBag.Message = "Your order has been successfully processed";
            return View();
        }

    }
}
