namespace MainProject3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelMain : DbContext
    {
        public ModelMain()
            : base("name=ModelMain")
        {
        }

        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Exhibition> Exhibitions { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Submit> Submits { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>()
                .Property(e => e.AwardID)
                .IsUnicode(false);

            modelBuilder.Entity<Award>()
                .HasMany(e => e.Exams)
                .WithOptional(e => e.Award)
                .HasForeignKey(e => e.IDAward);

            modelBuilder.Entity<Class>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.CommentID)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.MainID)
                .IsUnicode(false);

            modelBuilder.Entity<Competition>()
                .Property(e => e.CompetitionID)
                .IsUnicode(false);

            modelBuilder.Entity<Competition>()
                .Property(e => e.AwardID)
                .IsUnicode(false);

            modelBuilder.Entity<Competition>()
                .HasMany(e => e.Exams)
                .WithOptional(e => e.Competition)
                .HasForeignKey(e => e.IDCompetition);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.IDExhibition)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.IDExam)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.ExamID)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.IDStudent)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.IDCompetition)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.IDExhibition)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.IDAward)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Exam)
                .HasForeignKey(e => e.IDExam);

            modelBuilder.Entity<Exhibition>()
                .Property(e => e.ExhibitionID)
                .IsUnicode(false);

            modelBuilder.Entity<Exhibition>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Exhibition)
                .HasForeignKey(e => e.IDExhibition);

            modelBuilder.Entity<Exhibition>()
                .HasMany(e => e.Exams)
                .WithOptional(e => e.Exhibition)
                .HasForeignKey(e => e.IDExhibition);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffID)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Exams)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.IDStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Submit>()
                .Property(e => e.IDSubmit)
                .IsUnicode(false);

            modelBuilder.Entity<Submit>()
                .Property(e => e.Entity1ID)
                .IsUnicode(false);

            modelBuilder.Entity<Submit>()
                .Property(e => e.Entity2ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.IDUser)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Real_ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
