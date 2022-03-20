using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeLibraryPrj.Business
    
{
    class DisplayClients
    {
        private readonly ClientsManagement m = new ClientsManagement();
        public DisplayClients()
        {
                Input();
        }

        private void showMenu()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("1. List All");
            Console.WriteLine("2. Delete Client");
            Console.WriteLine("3. Retrieve Client by ID");
            Console.WriteLine("4. Add up a new client");
            Console.WriteLine("5. Update Client");
            Console.WriteLine("6. Calculate bill");
            Console.WriteLine("7. Exit");
        }

        private void Input()
        {
            
            Console.WriteLine(new string('-', 30));
            int a=-1;
            do
            {
                showMenu();
                Console.WriteLine(new string('-', 30));
                Console.WriteLine("Choose Client command: ");
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
                        Console.WriteLine("All clients:");
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
                        getBill();
                        break;
                    case 7:
                        Console.WriteLine(new string('-', 30));
                        break;
                }
                if (a != 7 && (a<1 || a>7))
                    Console.WriteLine("Enter valid command! ");               
            } while (a != 7);
            
        }

        private void ListAll()
        {
            var c = m.GetAll();
            foreach (var item in c)
                Console.WriteLine("{0} {1} {2} {3} {4}", item.ClientId, item.FirstName, item.LastName, item.TelNumber, item.Mail);
        }

        private void delete()
        {
            Console.WriteLine("Enter Clients ID to delete: ");
            var id = int.Parse(Console.ReadLine());
            if(m.Delete(id))
                Console.WriteLine("Deleted succesсfully");
            else Console.WriteLine("Client not found!");
        }

        private void retrieve()
        {
            try
            {
                Console.WriteLine("Enter Clients ID to retrieve: ");
                var id = int.Parse(Console.ReadLine());
                var client = m.Get(id);
                if (client != null)
                {
                    Console.WriteLine("ClientId: " + client.ClientId);
                    Console.WriteLine("FirstName: " + client.FirstName);
                    Console.WriteLine("LastName: " + client.LastName);
                    Console.WriteLine("Tel Number: " + client.TelNumber);
                    Console.WriteLine("Enter mail: " + client.Mail);
                }
                else
                {
                    Console.WriteLine("Client not found!");
                }
            }catch(Exception e)
            {
                Console.WriteLine("Invalid input");
            }
        
        }

        private void add()
        {
            try
            {
                Client client = new Client();
                Console.WriteLine("Enter FirstName: ");
                client.FirstName = Console.ReadLine();
                Console.WriteLine("Enter LastName: ");
                client.LastName = Console.ReadLine();
                Console.WriteLine("Enter TelNumber(not required): ");
                client.TelNumber = Console.ReadLine();
                Console.WriteLine("Enetr Mail(not required): ");
                client.Mail = Console.ReadLine();
                m.Add(client);
                Console.WriteLine("Added successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
            }
        }

        private void update()
        {
            try
            {
                Console.WriteLine("Enter ClientId to update: ");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter first name: ");
                var a = Console.ReadLine();
                Console.WriteLine("Enter famly name: ");
                var b = Console.ReadLine();
                Console.WriteLine("Enter phone number(not required): ");
                var c = Console.ReadLine();
                Console.WriteLine("Enter mail (not required): ");
                var d = Console.ReadLine();
                Client o = new Client(id, a, b, c, d);
                m.Update(o);
                Console.WriteLine("Updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
            }
        }

        public void getBill()
        {
            Console.WriteLine("Enter Id of Client to calculate his bill: ");
            int id = int.Parse(Console.ReadLine());
            if (m.GetBill(id) > 0)
                Console.WriteLine("Client's bill: " + m.GetBill(id).ToString("0.00") + " лв.");
            else Console.WriteLine("Client not found!");
        }
    }
}