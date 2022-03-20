using System;
using System.Collections.Generic;

namespace CafeLibraryPrj.DataModels.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }
        public Client(int id,string fn,string ln,string tel, string mail)
		{
            ClientId = id;
            FirstName = fn;
            LastName = ln;
            TelNumber = tel;
            Mail = mail;
		}

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public string Mail { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
