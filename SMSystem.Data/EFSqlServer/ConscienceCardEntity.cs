using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class ConscienceCardEntity : IDataHelper<ConscienceCard>
    {
        // Fileds
        private DBContext db;
        private ConscienceCard conscienceCard;

        // Methods
        public int Add(ConscienceCard table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<ConscienceCard>().Add(table);
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
                conscienceCard = Find(Id);
                db.ConscienceCard.Remove(conscienceCard);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(ConscienceCard table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<ConscienceCard>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ConscienceCard Find(int id)
        {
            db = new DBContext();
            return db.ConscienceCard.Where(x => x.Id == id).First();
        }
        public List<ConscienceCard> GetData()
        {
            try
            {
                db = new DBContext();
                return db.ConscienceCard.ToList();
            }
            catch { return null; }

        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<ConscienceCard> Search(string SearchItem)
        {
            db = new DBContext();
            return db.ConscienceCard.Where(x => x.DepTransportName.Contains(SearchItem)
            || x.MaterialName.Contains(SearchItem)
            || x.ReciverName.Contains(SearchItem)
            || x.ReciverSign.Contains(SearchItem)
            || x.DepTransportReciverName.Contains(SearchItem)
            || x.AddDate.ToString().Contains(SearchItem)
            || x.DepTransportReciverDate.ToString().Contains(SearchItem)
            || x.OutComeDate.ToString().Contains(SearchItem)
            || x.Quantity.ToString().Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
