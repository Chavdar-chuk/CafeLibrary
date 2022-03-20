using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CafeLibraryPrj.Data
{
    class BookData
    {
        public BookData() { }
        public void UpdateAvailability(int id)
        {
            bool flag = true;
            BookData bd = new BookData();
            List<Book> lb = bd.GetAll();
            foreach (var c in lb)
            {
                if (c.BookId == id)
                {
                    flag = c.IsAvailable;
                    break;
                }
            }
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand();
                if (flag)
                {
                    command = new SqlCommand("UPDATE Book SET isAvailable=0 WHERE BookId=@id", connection);
                }
                else command = new SqlCommand("UPDATE Book SET isAvailable=1 WHERE BookId=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void UpdateAvailabilityToTrue(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE Book SET isAvailable=1 WHERE BookId=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<Book> GetAll()
        {
            var BookList = new List<Book>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT*FROM Book", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var book = new Book(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetBoolean(4));
                        BookList.Add(book);
                    }
                }
                connection.Close();
            }
            return BookList;
        }
        public List<string> GetAllConcrete()
        {
            List<string> ls = new List<string>();
            using (var connection = Database.GetConnection())
            {
                string s = "";
                var command = new SqlCommand(
    "SELECT Book.BookId, Book.Author, Book.Title, Genres.Genre, Book.IsAvailable FROM Book join Genres on Genres.GenreId=Book.GenreId",
    connection);
                connection.Open();
                using (var reader1 = command.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        s = reader1.GetInt32(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " + reader1.GetString(3) + " " + reader1.GetBoolean(4);
                        ls.Add(s);
                    }
                    connection.Close();

                }
            }
            return ls;
        }
    }
}
