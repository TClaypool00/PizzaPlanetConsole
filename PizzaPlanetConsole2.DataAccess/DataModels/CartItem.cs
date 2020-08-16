using System;
using System.Collections.Generic;

namespace PizzaPlanetConsole.DataAccess.DataModels
{
    public partial class CartItem
    {
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }

        public virtual ShoppingCart Cart { get; set; }
        public virtual Foods Food { get; set; }
    }
}
