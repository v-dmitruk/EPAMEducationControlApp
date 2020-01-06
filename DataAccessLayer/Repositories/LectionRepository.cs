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
    class LectionRepository : IRepository<Lection>
    {
        private EduDBContext _db;
        public LectionRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(Lection item)
        {
            _db.Lections.Add(item);
        }

        public void Delete(int id)
        {
            Lection lection = _db.Lections.Find(id);
            if (lection != null)
                _db.Lections.Remove(lection);
        }

        public IEnumerable<Lection> Find(Func<Lection, bool> item)
        {
            return _db.Lections.Where(item).ToList();
        }

        public Lection Get(int id)
        {
            return _db.Lections.Find(id);
        }

        public IEnumerable<Lection> GetAll()
        {
            return _db.Lections;
        }

        public void Update(Lection item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
