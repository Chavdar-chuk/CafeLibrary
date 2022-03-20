using System;
using System.Collections.Generic;

namespace CafeLibraryPrj.DataModels.Models
{
    public class Drink
    {
        public Drink()
        {
            Orders = new HashSet<Order>();
        }

        public Drink(int id, int tid, string name, decimal p)
        {
            DrinkId = id;
            TypeId = tid;
            Name = name;
            Price = p;
        }

        public int DrinkId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public DrinkType Type { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
