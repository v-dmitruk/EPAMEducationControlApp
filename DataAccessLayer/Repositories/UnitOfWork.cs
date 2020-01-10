using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using DAL.EduDbContext;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private EduDBContext _db;
        private CourseRepository _courseRepository;
        private LectionRepository _lectionRepository;
        private LectionResultRepository _lectionResultRepository;
        private QuestionRepository _questionRepository;
        private ScheduledEventRepository _scheduledEventRepository;
        private StudentRepository _studentRepository;
        private TeacherRepository _teacherRepository;
        private TestRepository _testRepository;
        private TestResultRepository _testResultRepository;

        public UnitOfWork(string connectString)
        {
            _db = new EduDBContext(connectString);
        }
        public IRepository<Course> Courses
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new CourseRepository(_db);
                return _courseRepository;
            }
        }

        public IRepository<Lection> Lections
        {
            get
            {
                if (_lectionRepository == null)
                    _lectionRepository = new LectionRepository(_db);
                return _lectionRepository;
            }
        }

        public IRepository<LectionResult> LectionResults
        {
            get
            {
                if (_lectionResultRepository == null)
                    _lectionResultRepository = new LectionResultRepository(_db);
                return _lectionResultRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (_questionRepository == null)
                    _questionRepository = new QuestionRepository(_db);
                return _questionRepository;
            }

        }

        public IRepository<ScheduledEvent> ScheduledEvents
        {
            get
            {
                if (_scheduledEventRepository == null)
                    _scheduledEventRepository = new ScheduledEventRepository(_db);
                return _scheduledEventRepository;
            }
        }

        public IRepository<Student> Students
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_db);
                return _studentRepository;
            }
        }

        public IRepository<Teacher> Teachers
        {
            get
            {
                if (_teacherRepository == null)
                    _teacherRepository = new TeacherRepository(_db);
                return _teacherRepository;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (_testRepository == null)
                    _testRepository = new TestRepository(_db);
                return _testRepository;
            }
        }

        public IRepository<TestResult> TestResults
        {
            get
            {
                if (_testResultRepository == null)
                    _testResultRepository = new TestResultRepository(_db);
                return _testResultRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
