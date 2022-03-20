using CafeLibraryPrj.Data;
using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeLibraryPrj.Business
{
    class DrinksManagement
    {
        //Описва логиката на клас ClientsData

        private readonly DrinkData manager = new DrinkData();

        public List<Drink> GetAll()
        {
            return manager.getAll();
        }

        public List<string> getAllConcrete()
        {
            return manager.GetAllConcrete();
        }

       
    }
}
