using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Prj001_Bill.Models;
namespace Prj001_Bill.Models
{
    public class ModelDatabase : DbContext
    {
        public ModelDatabase() : base("cnString") { }

        public ModelDatabase(string connect) : base(connect) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Bill> tbBill { get; set; }
        public DbSet<Product> tbProduct { get; set; }
    }
}