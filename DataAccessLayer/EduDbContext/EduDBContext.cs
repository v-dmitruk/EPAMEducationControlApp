using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DAL.Models;

namespace DAL.EduDbContext
{
    public class EduDBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lection> Lections { get; set; }
        public DbSet<LectionResult> LectionResults { get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<ScheduledEvent> ScheduledEvents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

        static EduDBContext()
        {
            Database.SetInitializer<EduDBContext>(new DbInitializer());
        }
        public EduDBContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //FluentApi functionality
            base.OnModelCreating(modelBuilder);
        }


    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<EduDBContext>
    {

    }
}
