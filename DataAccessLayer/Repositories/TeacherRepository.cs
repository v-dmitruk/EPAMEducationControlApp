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
    class TeacherRepository : IRepository<Teacher>
    {
        private EduDBContext _db;
        public TeacherRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(Teacher item)
        {
            _db.Teachers.Add(item);
        }

        public void Delete(int id)
        {
            Teacher teacher = _db.Teachers.Find(id);
            if (teacher != null)
                _db.Teachers.Remove(teacher);
        }

        public IEnumerable<Teacher> Find(Func<Teacher, bool> item)
        {
            return _db.Teachers.Where(item).ToList();
        }

        public Teacher Get(int id)
        {
            return _db.Teachers.Find(id);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _db.Teachers;
        }

        public void Update(Teacher item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
