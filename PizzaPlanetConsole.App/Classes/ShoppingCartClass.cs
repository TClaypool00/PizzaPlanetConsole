using PizzaPlanetConsole.DataAccess.DataModels;
using System;

namespace PizzaPlanetConsole.App.Classes
{
    public class ShoppingCartClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static ShoppingCart AddCart(Users user, Store store)
        {
            var newCart = new ShoppingCart
            {
                UserId = user.UserId,
                StoreId = store.StoreId,
                TimeStamp = DateTime.UtcNow,
            };

            ctx.ShoppingCart.Add(newCart);
            ctx.SaveChanges();

            return newCart;
        }
    }
}
