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
            shopCart.listShopItems = shopCart.getShopItems();

            if(shopCart.listShopItems.Count == 0) {
                ModelState.AddModelError("", "You should add items to the cart");
                ViewBag.Message = "You should add items to the cart";
                return View("Errors");
            }

            Dictionary<string, int> dStock = new Dictionary<string, int>();
            foreach(var item in shopCart.listShopItems)
                if(!dStock.ContainsKey(item.car.Name))
                    dStock.Add(item.car.Name, item.car.Stock);

            shopCart.DecreaseStock();
            string lista = "";

            foreach(var item in shopCart.listShopItems)
                if(item.car.Stock < 0) {
                    if(!lista.Contains(item.car.Name)) {
                        lista += dStock[item.car.Name].ToString() + " " + item.car.Name + ", ";
                    }
                    ModelState.AddModelError("", "We don't dispose of this amount of cars you want to order");
                }

            if(!lista.Equals("")) {
                lista = lista.Remove(lista.Length - 2);
                ViewBag.Message = "Sorry, we do not have the amount of cars you want to order. We only have: " + lista + " car(s).";
                return View("Errors");
            }
            return View();
        }

        [HttpPost] // to work only after post method
        public IActionResult Checkout(Order order) {
            shopCart.listShopItems = shopCart.getShopItems();
            shopCart.DecreaseStock();
            if(ModelState.IsValid) {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete() {
            shopCart.UpdateStock();
            shopCart.DeleteAllFromCart();
            ViewBag.Message = "Your order has been successfully processed. We will contact you soon to establish the billing data, payment method & delivery process of your order.";
            return View();
        }

    }
}
