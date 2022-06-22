using Microsoft.EntityFrameworkCore;
using WebHocTap.Entity;

namespace WebHocTap.Data
{
    public class Context : DbContext
    {
        
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminAccount> AdminAccounts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Class_Course> Class_Course { get; set; }
        public virtual DbSet<Class_Test> Class_Test { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<LearningOutcome> LearningOutcomes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }


        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student_Test> Student_Test { get; set; }
        public virtual DbSet<StudentAccount> StudentAccounts { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestCategory> TestCategories { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.teacherId)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.AdminAccount)
                .WithOne(e => e.Admin1)
                .HasForeignKey(e => e.Admin);

            modelBuilder.Entity<AdminAccount>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<AdminAccount>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<AdminAccount>()
                .Property(e => e.Admin)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.classId)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Class_Course)
                .WithOne(e => e.Class1)
                .HasForeignKey(e => e.Class);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Class_Test)
                .WithOne(e => e.Class1)
                .HasForeignKey(e => e.Class);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Students)
                .WithOne(e => e.Class1)
                .HasForeignKey(e => e.Class);

            modelBuilder.Entity<Class_Course>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<Class_Test>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<Class_Test>()
                .HasMany(e => e.Student_Test)
                .WithOne(e => e.Class_Test1)
                .HasForeignKey(e => e.Class_Test);

            modelBuilder.Entity<Course>()
                .Property(e => e.linkOnline)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Class_Course)
                .WithOne(e => e.Course1)
                .HasForeignKey(e => e.Course);



            modelBuilder.Entity<Grade>()
                .Property(e => e.gradeName)
                .IsUnicode(false);

            modelBuilder.Entity<Grade>()
                .HasMany(e => e.Classes)
                .WithOne(e => e.Grade1)
                .HasForeignKey(e => e.Grade);

            modelBuilder.Entity<LearningOutcome>()
                .Property(e => e.Student)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Admins)
                .WithOne(e => e.Position1)
                .HasForeignKey(e => e.Position);



            modelBuilder.Entity<Student>()
                .Property(e => e.studentId)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.LearningOutcomes)
                .WithOne(e => e.Student1)
                .HasForeignKey(e => e.Student);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Student_Test)
                .WithOne(e => e.Student1)
                .HasForeignKey(e => e.Student);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentAccounts)
                .WithOne(e => e.Student1)
                .HasForeignKey(e => e.Student);

            modelBuilder.Entity<Student_Test>()
                .Property(e => e.Student)
                .IsUnicode(false);

            modelBuilder.Entity<Student_Test>()
                .HasMany(e => e.LearningOutcomes)
                .WithOne(e => e.Student_Test1)
                .HasForeignKey(e => e.Student_Test);

            modelBuilder.Entity<StudentAccount>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAccount>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAccount>()
                .Property(e => e.Student)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Admins)
                .WithOne(e => e.Subject1)
                .HasForeignKey(e => e.Subject);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Courses)
                .WithOne(e => e.Subject1)
                .HasForeignKey(e => e.Subject);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Documents)
                .WithOne(e => e.Subject1)
                .HasForeignKey(e => e.Subject);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.Class_Test)
                .WithOne(e => e.Test1)
                .HasForeignKey(e => e.Test);

            modelBuilder.Entity<TestCategory>()
                .HasMany(e => e.Tests)
                .WithOne(e => e.TestCategory1)
                .HasForeignKey(e => e.TestCategory);
        }
    }
}