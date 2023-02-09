using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class OutOfConsinceMaterialEntity : IDataHelper<OutOfConscinesMaterials>
    {
        // Fileds
        // Fileds
        private DBContext db;
        private OutOfConscinesMaterials damage;

        // Methods
        public int Add(OutOfConscinesMaterials table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<OutOfConscinesMaterials>().Add(table);
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
                db.OutOfConscinesMaterials.Remove(damage);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(OutOfConscinesMaterials table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<OutOfConscinesMaterials>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public OutOfConscinesMaterials Find(int id)
        {
            db = new DBContext();
            return db.OutOfConscinesMaterials.Where(x => x.Id == id).First();
        }
        public List<OutOfConscinesMaterials> GetData()
        {
            db = new DBContext();
            return db.OutOfConscinesMaterials.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<OutOfConscinesMaterials> Search(string SearchItem)
        {
            db = new DBContext();
            return db.OutOfConscinesMaterials.Where(x => x.Name.Contains(SearchItem)
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
