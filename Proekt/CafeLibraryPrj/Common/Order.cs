using System;
using System.Collections.Generic;

namespace CafeLibraryPrj.DataModels.Models
{
    public class Order
    {
        public Order()
        {
        }

        public Order(int order,int client,int? book, int drink)
		{
            OrderId = order;
            if (client < 0) throw new ArgumentException();
            ClientId = client;
            if (book <= 0 && book != null) throw new ArgumentException();
            BookId = book;
            if (drink < 0) throw new ArgumentException();
            DrinkId = drink;
		}

         public Order(int client,int? book, int drink)
		{
            if (client < 0) throw new ArgumentException();
            ClientId = client;
            if (book <= 0 && book != null) throw new ArgumentException();
            BookId = book;
            if (drink < 0) throw new ArgumentException();
            DrinkId = drink;
		}
        public int OrderId { get;  }
        public int ClientId 
        {
            get;
            set;
        }
        public int? BookId 
        {get;set;}
        public int DrinkId 
        {
            get;set;
        }

        public Book Book { get; set; }
        public Client Client { get; set; }
        public Drink Drink { get; set; }
    }
}
