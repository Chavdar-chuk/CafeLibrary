using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeLibraryPrj.Business

{
    class DisplayBooks
    {
        private readonly BooksManagement m = new BooksManagement();
        public DisplayBooks()
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
           
            Console.WriteLine(new string('-', 30));
            int a=-1;
            do
            {
                showMenu();
                Console.WriteLine("Choose Book command: ");
                try
                {
                    a = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter valid command!");Input();
                }
                switch (a)
                {
                    case 1:
                        Console.WriteLine("All books:");
                        
                        ListAll();
                        break;
                    case 2:
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Choose your next step: ");
                        break;
                }
                if (a != 2&& a!=1)
                    Console.WriteLine("Enter valid command!");
            } while (a != 2);
        }

        private void ListAll()
        {
            var c = m.getAllConcrete();
            foreach (var item in c)
                Console.WriteLine("{0}", item);
        }

       

      
    }
}
