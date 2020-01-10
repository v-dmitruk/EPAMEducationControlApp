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
    public class CourseRepository : IRepository<Course>
    {
        private EduDBContext _db;
        public CourseRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(Course item)
        {
            _db.Courses.Add(item);
        }

        public void Delete(int id)
        {
            Course course = _db.Courses.Find(id);
            if (course != null)
                _db.Courses.Remove(course);
        }

        public IEnumerable<Course> Find(Func<Course, bool> item)
        {
            return _db.Courses.Where(item).ToList();
        }

        public Course Get(int id)
        {
            return _db.Courses.Find(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _db.Courses.ToList();
        }

        public void Update(Course item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
