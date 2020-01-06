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
    class StudentRepository : IRepository<Student>
    {
        private EduDBContext _db;
        public StudentRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(Student item)
        {
            _db.Students.Add(item);
        }

        public void Delete(int id)
        {
            Student student = _db.Students.Find(id);
            if (student != null)
                _db.Students.Remove(student);
        }

        public IEnumerable<Student> Find(Func<Student, bool> item)
        {
            return _db.Students.Where(item).ToList();
        }

        public Student Get(int id)
        {
            return _db.Students.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Students;
        }

        public void Update(Student item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
