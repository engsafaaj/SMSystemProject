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
        private int resultAddOrEdit;
        private Stores stores;

        // Constructores
        public StoreEntity()
        {
            db = new DBContext();
        }

        // Methods
        public int Add(Stores table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Stores>().Add(table);
                resultAddOrEdit = 1;
                db.SaveChanges();
            }
            else
            {
                resultAddOrEdit = 0;

            }
            return resultAddOrEdit;
            db = null;
        }

        public int Delete(int Id)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                stores = Find(Id);
                db.Stores.Remove(stores);
                resultAddOrEdit = 1;
                db.SaveChanges();
            }
            else
            {
                resultAddOrEdit = 0;

            }
            return resultAddOrEdit;
            db = null;
        }

        public int Edit(Stores table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Stores>().Update(table);
                resultAddOrEdit = 1;
                db.SaveChanges();
            }
            else
            {
                resultAddOrEdit = 0;

            }
            return resultAddOrEdit;
            db = null;
        }

        public Stores Find(int id)
        {
            db = new DBContext();
            return db.Stores.Where(x => x.Id == id).First();
            db = null;
        }

        public List<string> GetColumnsList()
        {
            throw new NotImplementedException();
        }

        public List<Stores> GetData()
        {
            db = new DBContext();
            return db.Stores.ToList();
            db = null;
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
            db = null;
        }

        public List<Stores> Search(string SearchItem)
        {
            throw new NotImplementedException();
        }
    }
}
