using II_Shop.Data.interfaces;
using II_Shop.Data.Models;
using System;

namespace II_Shop.Data.Repository {
    public class OrdersRepository: IAllOrders {

        private readonly AppDbContent appDbContent; // to edit and save tables in database
        private readonly ShopCart shopCart; // all items that user want to buy
        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart) {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order order) {
            order.orderTime = DateTime.Now;
            appDbContent.Order.Add(order);
            appDbContent.SaveChanges();

            var items = shopCart.listShopItems;

            foreach(var el in items) {
                var orderDetail = new OrderDetail() {
                    CarId = el.car.Id,
                    orderId = order.id,
                    price = (uint)el.car.Price
                };
                appDbContent.OrderDetail.Add(orderDetail);
            }
            appDbContent.SaveChanges();
        }
    }
}
