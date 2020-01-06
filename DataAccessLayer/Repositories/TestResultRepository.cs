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
    class TestResultRepository : IRepository<TestResult>
    {
        private EduDBContext _db;
        public TestResultRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(TestResult item)
        {
            _db.TestResults.Add(item);
        }

        public void Delete(int id)
        {
            TestResult testResult = _db.TestResults.Find(id);
            if (testResult != null)
                _db.TestResults.Remove(testResult);
        }

        public IEnumerable<TestResult> Find(Func<TestResult, bool> item)
        {
            return _db.TestResults.Where(item).ToList();
        }

        public TestResult Get(int id)
        {
            return _db.TestResults.Find(id);
        }

        public IEnumerable<TestResult> GetAll()
        {
            return _db.TestResults;
        }

        public void Update(TestResult item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
