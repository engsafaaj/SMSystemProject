using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class OutComeMaterailMaterialsEntity : IDataHelper<OutComeMaterail>
    {
        // Fileds
        private DBContext db;
        private OutComeMaterail outComeMaterail;

        // Methods
        public int Add(OutComeMaterail table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<OutComeMaterail>().Add(table);
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
                outComeMaterail = Find(Id);
                db.outComeMaterail.Remove(outComeMaterail);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(OutComeMaterail table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<OutComeMaterail>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public OutComeMaterail Find(int id)
        {
            db = new DBContext();
            return db.outComeMaterail.Where(x => x.Id == id).First();
        }

        public List<OutComeMaterail> GetData()
        {
            db = new DBContext();
            return db.outComeMaterail.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<OutComeMaterail> Search(string SearchItem)
        {
            db = new DBContext();
            return db.outComeMaterail.Where(x => x.MaterialName.Contains(SearchItem)
            || x.Quantity.ToString().Contains(SearchItem)
            || x.TotalPrice.ToString().Contains(SearchItem) 
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
