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
    class TestRepository : IRepository<Test>
    {
        private EduDBContext _db;
        public TestRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(Test item)
        {
            _db.Tests.Add(item);
        }

        public void Delete(int id)
        {
            Test test = _db.Tests.Find(id);
            if (test != null)
                _db.Tests.Remove(test);
        }

        public IEnumerable<Test> Find(Func<Test, bool> item)
        {
            return _db.Tests.Where(item).ToList();
        }

        public Test Get(int id)
        {
            return _db.Tests.Find(id);
        }

        public IEnumerable<Test> GetAll()
        {
            return _db.Tests;
        }

        public void Update(Test item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
