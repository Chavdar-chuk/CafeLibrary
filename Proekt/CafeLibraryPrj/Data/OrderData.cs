using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CafeLibraryPrj.Data
{
    //Този клас служи за достъп до поръчките в базата данни
    class OrderData
    {
        //Този метод връща името и фамилията на клиент, поръчаното питие и заетата книга по зададено ID от таблицата Order
        public List<Order> GetAll()
        {
            var orderList = new List<Order>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand(
                   "SELECT * FROM Orders",
                    connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {                   
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(2))
                        {
                           var  order = new Order(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3)
                        );
                            orderList.Add(order);
                        }
                        else
                        {
                            var order = new Order(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            null,
                            reader.GetInt32(3)
                        );
                            orderList.Add(order);
                        }
                    }
                    
                } 
                connection.Close();
            }

            return orderList;
        }

        

        //Този метод връща обект от тип Order(ID на клиент,ID на книга, ID на питие)
        public Order Get(int id)
        {
            Order order = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Orders WHERE OrderId=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(2))
                        {
                            order = new Order(
                             reader.GetInt32(0),
                             reader.GetInt32(1),
                             reader.GetInt32(2),
                             reader.GetInt32(3)
                         );
                        }
                        else
                        {
                            order = new Order(
                           reader.GetInt32(0),
                           reader.GetInt32(1),
                           null,
                           reader.GetInt32(3)
                           );
                        }
                    }
                }

                connection.Close();
            }

            return order;
        }
        public bool isAvailable(Book book)
		{
            return book.IsAvailable;
		}
        //Този метод добавя Order(ID на клиента, ID на книга,ID на напитка)
        public void Add(Order orders)
        {
            var t = orders.BookId;
            bool flag = true;
            BookData bd = new BookData();
            List<Book> lb = bd.GetAll();

            foreach (var c in lb)
            {               
                if (c.BookId == (int)t)
                {
                    flag = c.IsAvailable; 
                    break;
                }
            }

            using (var connection = Database.GetConnection())
            {
                var command=new SqlCommand("");
                if (flag == true)
                {
                     command =
                    new SqlCommand(
                        "INSERT INTO Orders (ClientId, BookId, DrinkId) VALUES(@clientId, @bookId, @drinkId)",
                        connection);
                    command.Parameters.AddWithValue("bookId", orders.BookId);
                    bd.UpdateAvailability((int)t);                    
                }
                else
                {
                     command =
                    new SqlCommand(
                        "INSERT INTO Orders (ClientId, BookId, DrinkId) VALUES(@clientId,NULL, @drinkId)",
                        connection);
                    command.Parameters.AddWithValue(null, orders.BookId);

                }

                command.Parameters.AddWithValue("clientId", orders.ClientId);
                command.Parameters.AddWithValue("drinkId", orders.DrinkId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<string> GetAllConcrete(List<Order> lo)
        {
            List<string> ls = new List<string>();
            using (var connection = Database.GetConnection())
            {    
                        string s = "";                    
                           var command = new SqlCommand(
               "SELECT Orders.OrderId, Client.FirstName, Client.LastName, Book.Title,Drinks.Name FROM Orders join Client on Orders.ClientId = Client.ClientId join Book on Orders.BookId = Book.BookId join Drinks on Orders.DrinkId = Drinks.DrinkId",
               connection);
                            connection.Open();
                            using (var reader1 = command.ExecuteReader())
                            {
                                while (reader1.Read())
                                {
                        if (reader1.GetInt32(0) < 10)
                            s = "0" + reader1.GetInt32(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " + reader1.GetString(3) + " " + reader1.GetString(4);
                        else
                            s = reader1.GetInt32(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " + reader1.GetString(3) + " " + reader1.GetString(4);
                                    ls.Add(s);                  
                                }
                                connection.Close();
                            }
                            command = new SqlCommand(
                "SELECT Orders.OrderId, Client.FirstName, Client.LastName, book.Title, Drinks.Name from orders join Client on Orders.ClientId = Client.ClientId join Drinks on Orders.DrinkId = Drinks.DrinkId LEFT JOIN Book ON orders.bookId = book.bookId WHERE book.bookId IS  NULL",
                connection);
                            connection.Open();
                            using (var reader2 = command.ExecuteReader())
                            {
                                while (reader2.Read())
                                {
                                    s = reader2.GetInt32(0) + " " + reader2.GetString(1) + " " + reader2.GetString(2) + " Не е заел/а книга " + reader2.GetString(4);                            
                                    {
                                        ls.Add(s);                     
                                    }
                                 
                                }
                            }
                            connection.Close();                
            }
            return ls;
        }


        //Този метод актуализира обект Order(ID на клиента, ID на книга,ID на напитка) по подадено ID на поръчката
        public bool Update(Order orders)
        {
            using (var connection = Database.GetConnection())
            {
                try
                {
                    var command =
                        new SqlCommand(
                            "UPDATE orders SET ClientId=@clientid, BookId=@bookId, DrinkId=@drinkId WHERE OrderId=@id",
                            connection);
                    command.Parameters.AddWithValue("id", orders.OrderId);
                    BookData bd = new BookData();
                    bd.UpdateAvailability((int)orders.BookId);
                    command.Parameters.AddWithValue("clientId", orders.ClientId);
                    command.Parameters.AddWithValue("bookId", orders.BookId);
                    command.Parameters.AddWithValue("drinkId", orders.DrinkId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                
            }
        }
        //Този метод изтрива обект Order по подадено ID на поръчката 
        public bool Delete(int id)
        {
            OrderData od = new OrderData();
            List<Order> lo = od.GetAll();
            BookData bd = new BookData();
            int bid = 0;
            foreach(var e in lo)
            {
                if (e.OrderId == id)
                {
                    if(!(e.BookId is null))
                    bid =(int) e.BookId;
                }
            }
            bool f = isIdValid(id);
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE orders WHERE OrderId=@id", connection);
                command.Parameters.AddWithValue("id", id);
                bd.UpdateAvailability(bid);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return f;
            }
        }

        public bool isIdValid(int id)
        {
            List<Order> lo = GetAll();
            foreach (var e in lo)
            {
                if (e.OrderId == id) return true;
            }
            return false;
        }

        public void DeleteByClientId(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE orders WHERE ClientId=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}