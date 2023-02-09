using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class IncomeEntity : IDataHelper<Income>
    {
        // Fileds
        private DBContext db;
        private Income income;
        public IncomeEntity()
        {
            db = new DBContext();

        }

        // Methods
        public int Add(Income table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Income>().Add(table);
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
                income = Find(Id);
                db.Income.Remove(income);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(Income table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Income>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Income Find(int id)
        {
            db = new DBContext();
            return db.Income.Where(x => x.Id == id).First();
        }
        public List<Income> GetData()
        {
            db = new DBContext();
            return db.Income.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<Income> Search(string SearchItem)
        {
            db = new DBContext();
            return db.Income.Where(x => x.Name.Contains(SearchItem)
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
            || x.MaterailId.ToString().Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
