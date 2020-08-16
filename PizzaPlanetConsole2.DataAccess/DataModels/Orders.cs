using System;
using System.Collections.Generic;

namespace PizzaPlanetConsole.DataAccess.DataModels
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public decimal TotaLprice { get; set; }
        public int TotalQuantity { get; set; }

        public virtual ShoppingCart Cart { get; set; }
    }
}
