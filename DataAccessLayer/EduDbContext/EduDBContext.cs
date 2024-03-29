﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DAL.Models;
using System.Data.Entity.ModelConfiguration;

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
            base.Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //FluentApi functionality
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new LectionResultConfiguration());
            modelBuilder.Configurations.Add(new TestConfiguration());
            modelBuilder.Configurations.Add(new TestResultConfiguration());
            modelBuilder.Configurations.Add(new ScheduledEventConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new LectionConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }

    class TeacherConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            HasMany(p => p.CreatedQuestions).WithOptional(p => p.Creator); 
            HasMany(p => p.CreatedLections).WithOptional(p => p.Creator);
            HasMany(p => p.CreatedTests).WithOptional(p => p.Creator);
            HasMany(p => p.Courses).WithRequired(p => p.Creator);
            HasMany(x => x.ScheduledEvents).WithOptional(x => x.Creator);            
        }
    }

    class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            HasMany(x => x.Courses).WithMany(x => x.Students);
            HasMany(x => x.LectionResults).WithRequired(x => x.Student);
            HasMany(x => x.TestResults).WithRequired(x=>x.Student);
        }
    }

    class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasMany(x => x.Lections).WithMany(x => x.Courses);
            HasMany(x => x.Tests).WithMany(x => x.Courses);
            HasMany(x => x.LectionResults).WithRequired(x => x.Course);
            HasMany(x => x.TestResults).WithRequired(x => x.Course);
            HasMany(x => x.ScheduledEvents).WithRequired(x => x.Course);
        }
    }

    class LectionResultConfiguration : EntityTypeConfiguration<LectionResult>
    {
        public LectionResultConfiguration()
        {
            //HasOptional(x => x.Lection).WithMany(x => x.LectionResults);
            //HasRequired(x => x.Course).WithMany(x => x.LectionResults);
        }
    }

    class TestConfiguration : EntityTypeConfiguration<Test>
    {
        public TestConfiguration()
        {
            HasMany(x => x.TestResults).WithOptional(x => x.Test);
            HasMany(x => x.Questions);
            HasMany(x => x.ScheduledEvents).WithRequired(x => x.Test);
        }
    }

    class TestResultConfiguration : EntityTypeConfiguration<TestResult>
    {
        public TestResultConfiguration()
        {
            //HasRequired(x => x.Course).WithMany(x => x.TestResults);
            //HasOptional(x => x.Test).WithMany(x => x.TestResults);
        }
    }

    class ScheduledEventConfiguration : EntityTypeConfiguration<ScheduledEvent>
    {
        public ScheduledEventConfiguration()
        {
            //HasRequired(x => x.Course);
            //HasOptional(x => x.Lection);
            //HasOptional(x => x.Test);
            //HasOptional(x => x.Creator);
        }
    }

    class LectionConfiguration : EntityTypeConfiguration<Lection>
    {
        public LectionConfiguration()
        {
            HasMany(x => x.LectionResults).WithOptional(x => x.Lection);
            HasMany(x => x.ScheduledEvents).WithRequired(x => x.Lection);
        }
    }

    class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {

        }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<EduDBContext>
    {

    }

}
