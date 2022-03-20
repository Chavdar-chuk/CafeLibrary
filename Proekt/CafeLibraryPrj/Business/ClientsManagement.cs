using CafeLibraryPrj.Data;
using CafeLibraryPrj.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeLibraryPrj.Business
{
    class ClientsManagement
    {
        //Описва логиката на клас ClientsData
        
            private readonly ClientData manager = new ClientData();

            public List<Client> GetAll()
            {
                return manager.getAll();
            }

            public decimal getBill()
            {
            return manager.GetBillOfClient();
            }

            public Client Get(int id)
            {
                return manager.Get(id);
            }

            public void Add(Client grades)
            {
                manager.Add(grades);
            }

            public void Update(Client grades)
            {
                manager.Update(grades);
            }

            public bool Delete(int id)
            {
                return manager.Delete(id);
            }

            public decimal GetBill(int id)
            {
                return manager.GetBillOfClient(id);
            }
    }
}
