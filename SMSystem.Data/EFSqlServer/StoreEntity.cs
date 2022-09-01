using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class StoreEntity : IDataHelper<Stores>
    {
        // Fileds
        private DBContext db;
        private Stores stores;

        // Methods
        public int Add(Stores table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Stores>().Add(table);
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
                stores = Find(Id);
                db.Stores.Remove(stores);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(Stores table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Stores>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Stores Find(int id)
        {
            db = new DBContext();
            return db.Stores.Where(x => x.Id == id).First();
        }
        public List<Stores> GetData()
        {
            db = new DBContext();
            return db.Stores.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<Stores> Search(string SearchItem)
        {
            db = new DBContext();
            return db.Stores.Where(x => x.Name.Contains(SearchItem)
            || x.Description.Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
