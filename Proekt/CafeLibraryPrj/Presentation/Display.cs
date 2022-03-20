using CafeLibraryPrj.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace bob4e.Data.Models
{
    class Display
    {
        public Display()
        {
                Input();
        }

        private void showMenu()
        {
            Console.WriteLine("1. Drinks");
            Console.WriteLine("2. Books");
            Console.WriteLine("3. Clients");
            Console.WriteLine("4. Orders");
            Console.WriteLine("5. Exit");
        }

        private void Input()
        {
            int a = 0;
            do
            {
                showMenu();
                Console.WriteLine("Choose table to work with or exit:");
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
                        new DisplayDrinks();
                        break;
                    case 2:
                        new DisplayBooks();
                        break;
                    case 3:
                        new DisplayClients();
                        break;
                    case 4:
                        new DisplayOrders();
                        break;
                    case 5:
                        break;
                }
                if(a!=5 && (a>5||a<1))
                Console.WriteLine("Enter valid command!");
            } while (a != 5);
            if (a == 5) Console.WriteLine("Thank you for using our application!");
           
        }

    }
}

