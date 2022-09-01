using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class CustomersEntity : IDataHelper<Customers>
    {
        // Fileds
        private DBContext db;
        private Customers customers;

        // Methods
        public int Add(Customers table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Customers>().Add(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                customers = Find(Id);
                db.Customers.Remove(customers);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(Customers table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Customers>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Customers Find(int id)
        {
            db = new DBContext();
            return db.Customers.Where(x => x.Id == id).First();
        }
        public List<Customers> GetData()
        {
            db = new DBContext();
            return db.Customers.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<Customers> Search(string SearchItem)
        {
            db = new DBContext();
            return db.Customers.Where(x => x.Name.Contains(SearchItem)
            || x.Description.Contains(SearchItem)
            || x.Phone.Contains(SearchItem)
            || x.location.Contains(SearchItem)
            || x.Email.Contains(SearchItem)
            || x.Phone.Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
