using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class UserEntity : IDataHelper<User>
    {
        // Fileds
        private DBContext db;
        private User user;

        // Methods
        public int Add(User table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<User>().Add(table);
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
                user = Find(Id);
                db.User.Remove(user);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(User table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<User>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public User Find(int id)
        {
            db = new DBContext();
            return db.User.Where(x => x.Id == id).First();
        }
        public List<User> GetData()
        {
            db = new DBContext();
            return db.User.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<User> Search(string SearchItem)
        {
            db = new DBContext();
            return db.User.Where(x => x.FullName.Contains(SearchItem)
            || x.UserName.Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
