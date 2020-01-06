using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using DAL.EduDbContext;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    class LectionResultRepository : IRepository<LectionResult>
    {
        private EduDBContext _db;
        public LectionResultRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(LectionResult item)
        {
            _db.LectionResults.Add(item);
        }

        public void Delete(int id)
        {
            LectionResult lectionResult = _db.LectionResults.Find(id);
            if (lectionResult != null)
                _db.LectionResults.Remove(lectionResult);
        }

        public IEnumerable<LectionResult> Find(Func<LectionResult, bool> item)
        {
            return _db.LectionResults.Where(item).ToList();
        }

        public LectionResult Get(int id)
        {
            return _db.LectionResults.Find(id);
        }

        public IEnumerable<LectionResult> GetAll()
        {
            return _db.LectionResults;
        }

        public void Update(LectionResult item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
