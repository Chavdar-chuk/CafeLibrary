using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CafeLibraryPrj.Data
{
    class DrinkData
    {
        public List<Drink> getAll()
        {
            var DrinkList = new List<Drink>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT*FROM Drinks", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var drink = new Drink(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetDecimal(3));
                        DrinkList.Add(drink);
                    }
                }
                connection.Close();
            }
            return DrinkList;
        }

        public List<string> GetAllConcrete()
        {
            List<string> ls = new List<string>();
            using (var connection = Database.GetConnection())
            {
                string s = "";

                var command = new SqlCommand(
    "SELECT Drinks.DrinkId, DrinkTypes.DrinkType, Drinks.Name, Drinks.Price FROM Drinks join DrinkTypes on DrinkTypes.DrinkTypeId=Drinks.TypeID",
    connection);
                connection.Open();
                using (var reader1 = command.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        s = reader1.GetInt32(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " + reader1.GetDecimal(3).ToString("0.00")+" лв./бр.";
                        ls.Add(s);
                    }
                    connection.Close();

                }
            }
            return ls;
        }
    }
}
