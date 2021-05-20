using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace II_Shop.Data.Models {
    public class ShopCart {

        private readonly AppDbContent appDbContent;
        public ShopCart(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public ShopCartItem getCarFromShopCart(int carId) {
            var shopItems = getShopItems();
            return shopItems.FirstOrDefault(car => car.Id == carId);
        }
        public static ShopCart GetCart(IServiceProvider services) { // check if exist shop cart
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // create object to work with new session
            var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car) {
            appDbContent.ShopCartItem.Add(new ShopCartItem {
                ShopCartId = ShopCartId,
                car = car,
                price = car.Price
            });
            appDbContent.SaveChanges();
        }

        public void DeleteFromCart(ShopCartItem car) {
            appDbContent.ShopCartItem.Remove(getCarFromShopCart(car.Id));
            appDbContent.SaveChanges();
        }

        public void DeleteAllFromCart() {
            appDbContent.ShopCartItem.RemoveRange(appDbContent.ShopCartItem.ToList());
            appDbContent.SaveChanges();
        }

        public void DecreaseStock() {
            var shopList = getShopItems();
            foreach(var item in shopList)
                item.car.Stock--;
        }

        public void UpdateStock() {
            var shopList = getShopItems();
            foreach(var item in shopList)
                appDbContent.Car.Update(item.car);
            appDbContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems() {
            return appDbContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
