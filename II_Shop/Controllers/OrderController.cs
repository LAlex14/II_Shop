﻿using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace II_Shop.Controllers {
    public class OrderController : Controller {

        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart) {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout() {
            return View();
        }

        [HttpPost]
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
            ViewBag.Message = "Your order has been successfully processed";
            return View();
        }

    }
}
