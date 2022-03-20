using bob4e.Data.Models;
using CafeLibraryPrj.Data;
using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;

namespace CafeLibraryPrj
{
	class Program
	{
		static void Main(string[] args)
		{
			//ClientData cd = new ClientData();
			//OrderData od = new OrderData();
			//Client c = cd.Get(4);
			//Client cl = new Client(3,"Ivan", "Andonov",null,null);
			//cd.Add(cl);
			//cd.Delete(5);
			//List<Client> lc = cd.getAll();
			//decimal d = cd.GetBillOfClient();
			//Console.WriteLine(c.ClientId + " " + c.FirstName + " " + c.LastName + " " + c.TelNumber + " " + c.Mail);
			/*foreach(var e in lc)
			{
				Console.WriteLine(e.ClientId +" "+ e.FirstName +" "+ e.LastName +" "+ e.TelNumber +" "+ e.Mail);
			}*/
			//Order order = new Order(1, 17, 12, 18);
			/*od.Delete(48);
			List<Order> lo = od.GetAll();
			foreach(var e in lo)
            {
				if(e.BookId!=null)
				Console.WriteLine(e.DrinkId + " " + e.ClientId + " " + e.BookId+" "+ e.DrinkId);
				else Console.WriteLine(e.DrinkId + " " + e.ClientId + " NULL " + e.DrinkId);
			}*/
			/*List<string> ls = od.GetAllConcrete(lo);
			foreach (var e in ls)
			{
				Console.WriteLine(e);
			}*/
			Console.WriteLine("               _____      .____    ._____.                              ");
			Console.WriteLine("  ____ _____ _/ ____\\____ |    |   |__\\_ |______________ _______ ___.__.");
			Console.WriteLine("_/ ___\\\\__  \\\\   __\\/ __ \\|    |   |  || __ \\_  __ \\__  \\\\_  __ <   |  |");
			Console.WriteLine("\\  \\___ / __ \\|  | \\  ___/|    |___|  || \\_\\ \\  | \\// __ \\|  | \\/\\___  |");
			Console.WriteLine(" \\___  >____  /__|  \\___  >_______ \\__||___  /__|  (____  /__|   / ____|");
			Console.WriteLine("     \\/     \\/          \\/        \\/       \\/           \\/       \\/     ");

			Display d = new Display();
		}
	}
}
