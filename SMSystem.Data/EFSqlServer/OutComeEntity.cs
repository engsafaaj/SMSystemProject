using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class OutComeEntity : IDataHelper<OutCome>
    {
        // Fileds
        private DBContext db;
        private OutCome outCome;

        // Methods
        public int Add(OutCome table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<OutCome>().Add(table);
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
                outCome = Find(Id);
                db.OutCome.Remove(outCome);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(OutCome table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<OutCome>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public OutCome Find(int id)
        {
            db = new DBContext();
            return db.OutCome.Where(x => x.Id == id).First();
        }

        public List<OutCome> GetData()
        {
            db = new DBContext();
            return db.OutCome.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<OutCome> Search(string SearchItem)
        {
            db = new DBContext();
            return db.OutCome.Where(x => x.Customer.Contains(SearchItem)
            || x.AddedDate.ToString().Contains(SearchItem)
            || x.OutDate.ToString().Contains(SearchItem) 
            || x.OuterNo.ToString().Contains(SearchItem) 
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
