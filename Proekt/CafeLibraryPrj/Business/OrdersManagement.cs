using CafeLibraryPrj.Data;
using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeLibraryPrj.Business
{
    class OrdersManagement
    {
        //Описва логиката на клас ClientsData

        private readonly OrderData manager = new OrderData();

        public List<string> GetAll()
        {
            return manager.GetAllConcrete(manager.GetAll());
        }

        public Order Get(int id)
        {
            return manager.Get(id);
        }

        public void Add(Order grades)
        {
            manager.Add(grades);
        }

        public bool Update(Order grades)
        {
            return manager.Update(grades);
        }

        public bool Delete(int id)
        {
            return manager.Delete(id);
        }

        
    }
}
