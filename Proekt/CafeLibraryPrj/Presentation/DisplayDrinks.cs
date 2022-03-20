using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeLibraryPrj.Business

{
    class DisplayDrinks
    {
        private readonly DrinksManagement m = new DrinksManagement();
        public DisplayDrinks()
        {
                Input();
        }

        private void showMenu()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("1. List All");
            Console.WriteLine("2. Exit");
        }

        private void Input()
        {
            showMenu();
            Console.WriteLine(new string('-', 30));
            int a=-1;
            do
            {
                Console.WriteLine("Choose Drink command: ");
                try
                {
                    a = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter valid command!"); Input();
                }
                switch (a)
                {
                    case 1:
                        Console.WriteLine(new string('-', 30));
                        ListAll();
                        break;
                    case 2:
                        Console.WriteLine(new string('-', 30));
                        break;
                }
                if (a != 2 && a!=1)
                    Console.WriteLine("Enter valid command!");               
            } while (a != 2);
        }

        private void ListAll()
        {
            var c = m.getAllConcrete();
            foreach (var item in c)
                Console.WriteLine(item);
        }
    }
}
