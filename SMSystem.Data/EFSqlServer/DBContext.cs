using Microsoft.EntityFrameworkCore;
using SMSystem.Core;

namespace SMSystem.Data.EF
{
    public class DBContext : DbContext
    {

        // Constructores
        public DBContext()
        {

        }
        //Methods -- Override
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var DevelopmentConString = @"Server=.\SQLEXPRESS;DataBase=DBSMSystem;Integrated Security=True";
            //optionsBuilder.UseSqlServer(ConfigDictionary.keyValuePairs["ConString"]);
            optionsBuilder.UseSqlServer(DevelopmentConString);
        }
        // Tables
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Materails> Materails { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Income> Income { get; set; }
    }
}
