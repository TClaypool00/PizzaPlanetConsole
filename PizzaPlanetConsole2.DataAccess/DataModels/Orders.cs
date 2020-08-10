using System;
using System.Collections.Generic;

namespace PizzaPlanetConsole2.DataAccess.DataModels
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string FoodIds { get; set; }
        public int? TotalQuantity { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual Users Customer { get; set; }
        public virtual Stores Store { get; set; }
    }
}
