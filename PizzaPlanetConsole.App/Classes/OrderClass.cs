using PizzaPlanetConsole2.DataAccess.DataModels;
using System;

namespace PizzaPlanetConsole.App.Classes
{
    public class OrderClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void AddToOrder(string ids, Users user, Stores store, decimal price)
        {
            var newOrder = new Orders
            {
                StoreId = store.StoreId,
                CustomerId = user.UserId,
                OrderDate = DateTime.UtcNow,
                TotalQuantity = FoodClass.OrderList.Count,
                FoodIds = ids,
                OrderTotal = price,
            };

            ctx.Orders.Add(newOrder);
            ctx.SaveChanges();
        }
    }
}
