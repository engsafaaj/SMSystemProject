using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
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
            optionsBuilder.UseSqlServer(ConfigDictionary.keyValuePairs["ConString"]);
        }
        // Tables
        public DbSet<Stores> Stores { get; set; }
    }
}
