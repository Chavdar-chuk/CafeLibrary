using CafeLibraryPrj.Data;
using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeLibraryPrj.Business
{
    class BooksManagement
    {
        //Описва логиката на клас ClientsData

        private readonly BookData manager = new BookData();

        public List<string> getAllConcrete()
        {
            return manager.GetAllConcrete();
        }


    }
}
