//
using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CafeLibraryPrj.Data
{//Този клас служи за достъп до учениците в базата данни
    class ClientData
    {//Този метод връща всички клиенти, които са в базата (ID на клиента, име, фамилия, телефон, имейл)
        public List<Client> getAll()
        {
            var ClientList = new List<Client>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT*FROM Client", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var client = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                        ClientList.Add(client);
                    }
                }
                connection.Close();
            }
            return ClientList;
        }

        internal decimal GetBillOfClient()
        {
            throw new NotImplementedException();
        }

        //Този метод връща клиент по подадено ID (ID на клиент, име, фамилия, телефон, имейл)
        public Client Get(int id)
        {
            Client client = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM client WHERE ClientId=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        client = new Client(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                        );
                }
                connection.Close();
            }

            return client;
        }

        //Този метод добавя клиент (име, фамилия, телефон, имейл)
        public void Add(Client client) 
        {
            
                using (var connection = Database.GetConnection())
                {
                    var command =
                    new SqlCommand(
                    "INSERT INTO client (FirstName, LastName, TelNumber, Mail) VALUES(@firstName, @lastName, @telNumber, @mail)",
                    connection);
                    command.Parameters.AddWithValue("firstName", client.FirstName);
                    command.Parameters.AddWithValue("lastName", client.LastName);
//PROBLEM S NULL !!!
                    command.Parameters.AddWithValue("telNumber", client.TelNumber);
                    command.Parameters.AddWithValue("mail", client.Mail);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            
        }

        //Този метод актуализира таблица client в базата по подадено ID
        public void Update(Client client)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE client SET FirstName=@firstName, LastName=@lastName, TelNumber=@telnumber, Mail=@mail WHERE ClientId=@id", connection);
                command.Parameters.AddWithValue("id", client.ClientId);
                command.Parameters.AddWithValue("firstName", client.FirstName);
                command.Parameters.AddWithValue("lastName", client.LastName);
                command.Parameters.AddWithValue("telNumber", client.TelNumber);
                command.Parameters.AddWithValue("mail", client.Mail);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Този метод изтрива данните за клиент по подадено ID в таблица Client в базата
        public bool Delete(int id)
        {
            bool f = isIdValid(id);
            try
            {
                using (var connection = Database.GetConnection())
                {
                    var command = new SqlCommand("DELETE client WHERE ClientId=@id", connection);
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return f;
                }
            }
            catch(Exception e)
            {
                OrderData od = new OrderData();
                od.DeleteByClientId(id);
                Delete(id);
                return f;
            }
        }

        public bool isIdValid(int id)
        {

            List<Client> lc = getAll();
            foreach (var e in lc)
            {
                if (e.ClientId == id) return true;
            }
            return false;

        }

        public decimal GetBillOfClient(int id)
        {
            OrderData od = new OrderData();
            decimal sum = 0;
            bool flag = isIdValid(id);
            if (flag)
            {
                using (var connection = Database.GetConnection())
                {
                    var command = new SqlCommand("SELECT Drinks.Price FROM Orders join Drinks on Drinks.DrinkId=Orders.DrinkId WHERE Orders.ClientId=@id");
                    command.Parameters.AddWithValue("id", id);
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sum = sum + reader.GetDecimal(0);
                        }
                    }
                    connection.Close();
                }
                return sum;
            }
            return -1;
        }
    }
}