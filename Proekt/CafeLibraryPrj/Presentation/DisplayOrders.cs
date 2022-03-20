using System;
using System.Collections.Generic;
using System.Text;
using CafeLibraryPrj.Business;
using CafeLibraryPrj.DataModels.Models;

namespace CafeLibraryPrj.Business
{
    class DisplayOrders
    {
        private readonly OrdersManagement m = new OrdersManagement();
        public DisplayOrders()
        {
                Input();
        }

        private void showMenu()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("1. List All");
            Console.WriteLine("2. Delete Order");
            Console.WriteLine("3. Retrieve Order by ID");
            Console.WriteLine("4. Add up a new order");
            Console.WriteLine("5. Update");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            showMenu();
            int a=-1;
            do
            {              
                Console.WriteLine(new string('-', 30));
                Console.WriteLine("Choose Order command: ");
                try
                {
                    a = int.Parse(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.WriteLine("Enter valid command!");Input();
                }
                switch (a)
                {

                    case 1:
                        Console.WriteLine("All orders:");
                        Console.WriteLine(new string('-', 30));
                        ListAll();
                        break;
                    case 2:
                        Console.WriteLine(new string('-', 30));
                        delete();
                        break;
                    case 3:
                        Console.WriteLine(new string('-', 30));
                        retrieve();
                        break;
                    case 4:
                        Console.WriteLine(new string('-', 30));
                        add();
                        break;
                    case 5:
                        Console.WriteLine(new string('-', 30));
                        update();
                        break;
                    case 6:
                        Console.WriteLine(new string('-', 30));
                        break;
                }
                if (a != 6 && (a>6 || a<1))
                    Console.WriteLine("Enter valid command!");
            } while (a != 6) ;
        }

        public void ListAll()
        {
            List<string> c = m.GetAll();
            for (int i = 0; i < c.Count; i++)
            {
                for (int j = i; j < c.Count; j++)
                {
                    if (c[i].Substring(0, 2).CompareTo(c[j].Substring(0, 2)) > 0)
                    {
                        string t = c[i];
                        c[i] = c[j];
                        c[j] = t;
                    }
                }
                
            }
            foreach (var item in c)
                Console.WriteLine(item);
        }

        public void delete()
        {
            Console.WriteLine("Enter Order ID to delete: ");
            var id = int.Parse(Console.ReadLine());
            if(m.Delete(id))
            Console.WriteLine("Deleted successfully.");
            else Console.WriteLine("Order not found!");
        }

        public void retrieve()
        {
            try
            {
                Console.WriteLine("Enter Order ID to fetch: ");
                var id = int.Parse(Console.ReadLine());
                var order = m.Get(id);
                if (order != null)
                {
                    Console.WriteLine("OrderId: " + order.OrderId);
                    Console.WriteLine("ClientId: " + order.ClientId);
                    Console.WriteLine("BookId: " + order.BookId);
                    Console.WriteLine("DrinkId: " + order.DrinkId);
                }
                else
                {
                    Console.WriteLine("Order not found!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
            }

        }

        public void add()
        {
            try { 
                Console.WriteLine("Enter Id Client: ");
                var a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Id Book: ");
                var b = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Id Drink: ");
                var c = int.Parse(Console.ReadLine());
                Order o = new Order(a, b, c);
                m.Add(o);
                Console.WriteLine("Added successfully");
            }catch(Exception e)
            {
                Console.WriteLine("Invalid input");
            }
            
        }

        public void update()
        {
            Console.WriteLine("Enter OrderId to update: ");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Id Client: ");
            var a = int.Parse(Console.ReadLine());
             Console.WriteLine("Enter Id Book: ");
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Id Drink: ");
            var c = int.Parse(Console.ReadLine());
            Order o = new Order(id,a,b,c);
            if(m.Update(o))
            Console.WriteLine("Updated successfully");
            else Console.WriteLine("Invalid input");
        }
    }
}
