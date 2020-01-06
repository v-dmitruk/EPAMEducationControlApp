using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Course> Courses { get; }
        IRepository<Lection> Lections { get; }
        IRepository<LectionResult> LectionResults { get; }
        IRepository<Question> Questions { get; }
        IRepository<ScheduledEvent> ScheduledEvents { get; }
        IRepository<Student> Students { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Test> Tests { get; }
        IRepository<TestResult> TestResults { get; }
        void Save();
    }
}
