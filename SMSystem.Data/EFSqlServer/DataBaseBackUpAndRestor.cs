using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace SMSystem.Data.EFSqlServer
{
    public class DataBaseBackUpAndRestor
    {
        DBContext db;
        public DataBaseBackUpAndRestor()
        {
            db = new DBContext();
        }
        public string BackUp(string SelectedPath, string dbname)
        {
            try
            {
                db = new DBContext();
                string dbBackUp = dbname + DateTime.Now.ToString("yyyyMMddHHmm");
                var fullpath = SelectedPath + dbBackUp + ".bak";
                string sqlCommand = @"BACKUP DATABASE ["+dbname+"] TO  DISK = '" + fullpath + "' WITH NOFORMAT, NOINIT,  NAME = N'" + dbname + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                int path = db.Database.ExecuteSqlRaw(sqlCommand);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string RestoreDataBase(string FileName, string dbname)
        {
            try
            {
                db = new DBContext();

                string AlterDbSetSingle = "ALTER DATABASE [" + dbname + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                string AlterDbSetDouble = ";ALTER DATABASE [" + dbname + "] SET MULTI_USER";

                string sqlCommand = AlterDbSetSingle+@"USE [master]
RESTORE DATABASE [" + dbname + "] FROM  DISK = N'" + FileName + "' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 5"+ AlterDbSetDouble;
                int path = db.Database.ExecuteSqlRaw(sqlCommand);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
