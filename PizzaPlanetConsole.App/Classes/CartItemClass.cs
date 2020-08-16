using PizzaPlanetConsole.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPlanetConsole.App.Classes
{
    public class CartItemClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void AddItem(ShoppingCart cart, int foodId)
        {
            Console.Write("How many do you want? ");
            int num = int.Parse(Console.ReadLine());

            var newItem = new CartItem
            {
                CartId = cart.CartId,
                FoodId = foodId,
                Quantity = num
            };

            ctx.CartItem.Add(newItem);
            ctx.SaveChanges();
        }
    }
}
