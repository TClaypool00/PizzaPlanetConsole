using System;
using System.Collections.Generic;

namespace PizzaPlanetConsole2.DataAccess.DataModels
{
    public partial class Foods
    {
        public Foods()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int FoodId { get; set; }
        public int FoodGroupId { get; set; }
        public string FoodTitle { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual FoodGroup FoodGroup { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
