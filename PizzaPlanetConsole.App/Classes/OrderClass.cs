using Microsoft.EntityFrameworkCore;
using PizzaPlanetConsole.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlanetConsole.App.Classes
{
    public class OrderClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static List<Orders> MyOrders(Users user)
        {
            var myOrders = ctx.Orders
                .Include(s => s.Cart)
                .ThenInclude(a => a.User)
                .Where(u => u.Cart.User.UserId == user.UserId)
                .ToList();

            return myOrders;
        }

        public static void AddOrder(decimal totalPrice, int cartId)
        {
            var newOrder = new Orders
            {
                CartId = cartId,
                TotaLprice = totalPrice,
                TotalQuantity = CalcQuanity(cartId)
            };

            ctx.Orders.Add(newOrder);
            ctx.SaveChanges();
            Console.WriteLine("Your order has been placed!");
        }

        public static decimal CalcTotal(int cartId)
        {
            decimal total = 0;

            var cartItem = GetItems(cartId);

            foreach (var item in cartItem)
            {
                decimal price = item.Food.Price * item.Quantity;

                total += price;
            }

            return total;
        }

        public static int CalcQuanity(int cartId)
        {
            var items = GetItems(cartId);

            return items.Count;
        }

        public static List<CartItem> GetItems(int cartId)
        {
            var cartItem = ctx.CartItem
                .Include(f => f.Food)
                .Where(a => a.CartId == cartId)
                .ToList();

            return cartItem;
        }

        public static void UserPays(decimal orderTotal)
        {
            Console.WriteLine($"Your total is {orderTotal:C2}");
            while (true)
            {
                decimal pay = decimal.Parse(Console.ReadLine());

                if (pay == orderTotal)
                    break;
                else if(pay > orderTotal)
                {
                    Console.WriteLine("Thanks for the tip"!);
                    break;
                }
                else
                    Console.WriteLine("Incorrect amount");
            }
        }

        public static void OrderDetails(int id, Users user)
        {
            try
            {
                var order = ctx.Orders
                    .Include(a => a.Cart)
                    .ThenInclude(s => s.CartItem)
                    .ThenInclude(f => f.Food)
                    .ThenInclude(g => g.FoodGroup)
                    .Include(a => a.Cart)
                    .ThenInclude(c => c.Store)
                    .FirstOrDefault(o => o.OrderId == id);

                foreach (var item in order.Cart.CartItem)
                {
                    Console.WriteLine($"{item.Food.FoodTitle} {item.Food.FoodGroup.FoodGroups} {item.Food.Price:C2} X {item.Quantity}");
                }

                Console.WriteLine($"\nTotal No. of Items: {order.TotalQuantity} \nTotal Price {order.TotaLprice:C2} \n{order.Cart.TimeStamp}\n From {order.Cart.Store.Street}, {order.Cart.Store.Street}");
            }
            catch (NullReferenceException)
            {
                Console.Write("Not an option. Try again.");
                GeneralClass.PressEnter();
                Console.WriteLine();
                int orderId = Display.DisplayList(user);
                OrderDetails(orderId, user);
            }
        }
    }
}
