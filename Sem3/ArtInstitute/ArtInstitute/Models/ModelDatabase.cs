using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ArtInstitute.Models;

namespace ArtInstitute.Models
{
    public class ModelDatabase : DbContext
    {
        public ModelDatabase() : base("CNString") { }
        public ModelDatabase(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Award> tbAward { get; set; }
        public DbSet<Comment> tbComment { get; set; }
        public DbSet<Competition> tbCompetition { get; set; }
        public DbSet<Customer> tbCustomer { get; set; }
        public DbSet<Exam> tbExam { get; set; }
        public DbSet<Exhibition> tbExhibition { get; set; }
        public DbSet<Manager> tbManager { get; set; }
        public DbSet<Staff> tbStaff { get; set; }
        public DbSet<Student> tbStudent { get; set; }
        public DbSet<User> tbUser { get; set; }

    }
}