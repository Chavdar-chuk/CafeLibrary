using System;
using System.Collections.Generic;

namespace CafeLibraryPrj.DataModels.Models
{
    public class DrinkType
    {
        public DrinkType()
        {
            Drinks = new HashSet<Drink>();
        }

        public int DrinkTypeId { get; set; }
        public string DrinkTypeName { get; set; }

        public ICollection<Drink> Drinks { get; set; }
    }
}
