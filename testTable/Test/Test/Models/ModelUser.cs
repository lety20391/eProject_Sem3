namespace Test.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelUser : DbContext
    {
        public ModelUser()
            : base("name=ModelUser")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserID)
                .IsUnicode(false);
        }
    }
}
