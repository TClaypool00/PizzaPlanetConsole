using System;
using System.Collections.Generic;

namespace PizzaPlanetConsole2.DataAccess.DataModels
{
    public partial class FoodGroup
    {
        public FoodGroup()
        {
            Foods = new HashSet<Foods>();
        }

        public int FoodGroupId { get; set; }
        public string FoodGroups { get; set; }

        public virtual ICollection<Foods> Foods { get; set; }
    }
}
