using System;
using System.Collections.Generic;

namespace CafeLibraryPrj.DataModels.Models
{
    public class Genre
    {
        public Genre()
        {
            Book = new HashSet<Book>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
