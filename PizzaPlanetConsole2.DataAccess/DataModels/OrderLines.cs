using System;
using System.Collections.Generic;

namespace PizzaPlanetConsole2.DataAccess.DataModels
{
    public partial class OrderLines
    {
        public int OrderlineId { get; set; }
        public int FoodId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Foods Food { get; set; }
        public virtual Orders Order { get; set; }
    }
}
