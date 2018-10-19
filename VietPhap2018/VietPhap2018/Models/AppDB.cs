using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using VietPhap2018.Models;

namespace VietPhap2018.Models
{
    public class AppDB : DbContext
    {
        public AppDB() : base("ConnectString") { }

        public AppDB(string connect) : base(connect) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Report> tbReport { get; set; }
    }
}