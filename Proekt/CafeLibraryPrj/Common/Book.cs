using System;
using System.Collections.Generic;

namespace CafeLibraryPrj.DataModels.Models
{
    public class Book
    {
		private object bookId;

        public Book()
        {
        }

        public Book(int? bookId)
        {
            Orders = new HashSet<Order>();
        }

		public Book(int bookId,string title,string author,int genreid,bool isav)
		{
			this.BookId = bookId;
            this.Title = title;
            this.Author = author;
            this.GenreId = genreid;
            this.IsAvailable = isav;
		}

		public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
        public bool IsAvailable { get; set; }

        public Genre Genre { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
