using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
                ViewBag.Message = "You should add items to the cart";
                return View("Errors");
            }

            shopCart.DecreaseStock();

            string lista = "";

            foreach (var item in shopCart.listShopItems)
                if (item.car.Stock < 0)
                {
                    if (!lista.Contains(item.car.Name))
                        lista += item.car.Name + ", ";
                    ModelState.AddModelError("", "We don't dispose of this amount of cars you want to order");
                }

            if(!lista.Equals(""))
            {
                lista = lista.Remove(lista.Length - 2);
                ViewBag.Message = "We don't dispose of this amount of " + lista + " you want to order";
                return View("Errors");
            }

            if (ModelState.IsValid) {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);

        }

        public IActionResult Complete() {

            shopCart.UpdateStock();

            shopCart.DeleteAllFromCart();

            ViewBag.Message = "Your order has been successfully processed";
            return View();
        }

    }
}
