using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class DamageEntity : IDataHelper<Damage>
    {
        // Fileds
        private DBContext db;
        private Damage damage;

        // Methods
        public int Add(Damage table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Damage>().Add(table);
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
                damage = Find(Id);
                db.Damage.Remove(damage);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(Damage table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Damage>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Damage Find(int id)
        {
            db = new DBContext();
            return db.Damage.Where(x => x.Id == id).First();
        }
        public List<Damage> GetData()
        {
            db = new DBContext();
            return db.Damage.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<Damage> Search(string SearchItem)
        {
            db = new DBContext();
            return db.Damage.Where(x => x.Name.Contains(SearchItem)
            || x.Unit.Contains(SearchItem)
            || x.Code.Contains(SearchItem)
            || x.Store.Contains(SearchItem)
            || x.State.Contains(SearchItem)
            || x.ReciptNo.Contains(SearchItem)
            || x.RectipName.Contains(SearchItem)
            || x.RectipDate.ToString().Contains(SearchItem)
            || x.InterNo.ToString().Contains(SearchItem)
            || x.Supplier.Contains(SearchItem)
            || x.AddedDate.ToString().Contains(SearchItem)
            || x.ExpDate.ToString().Contains(SearchItem)
            || x.Quantity.ToString().Contains(SearchItem)
            || x.Price.ToString().Contains(SearchItem)
            || x.TotalPrice.ToString().Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
