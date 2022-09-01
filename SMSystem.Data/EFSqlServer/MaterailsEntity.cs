using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class MaterailsEntity : IDataHelper<Materails>
    {
        // Fileds
        private DBContext db;
        private Materails materails;

        // Methods
        public int Add(Materails table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Materails>().Add(table);
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
                materails = Find(Id);
                db.Materails.Remove(materails);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(Materails table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Materails>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Materails Find(int id)
        {
            db = new DBContext();
            return db.Materails.Where(x => x.Id == id).First();
        }
        public List<Materails> GetData()
        {
            try
            {
                db = new DBContext();
                return db.Materails.ToList();
            }
            catch { return null; }

        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<Materails> Search(string SearchItem)
        {
            db = new DBContext();
            return db.Materails.Where(x => x.Name.Contains(SearchItem)
            || x.Unit.Contains(SearchItem)
            || x.Code.Contains(SearchItem)
            || x.Store.Contains(SearchItem)
            || x.Descritpion.Contains(SearchItem)
            || x.Quantity.ToString().Contains(SearchItem)
            || x.InCome.ToString().Contains(SearchItem)
            || x.OutCome.ToString().Contains(SearchItem)
            || x.Price.ToString().Contains(SearchItem)
            || x.TotalPrice.ToString().Contains(SearchItem)
            || x.StoreId.ToString().Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
