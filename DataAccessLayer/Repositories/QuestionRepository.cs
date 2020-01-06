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
    class QuestionRepository : IRepository<Question>
    {
        private EduDBContext _db;
        public QuestionRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(Question item)
        {
            _db.Questions.Add(item);
        }

        public void Delete(int id)
        {
            Question question = _db.Questions.Find(id);
            if (question != null)
                _db.Questions.Remove(question);
        }

        public IEnumerable<Question> Find(Func<Question, bool> item)
        {
            return _db.Questions.Where(item).ToList();
        }

        public Question Get(int id)
        {
            return _db.Questions.Find(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _db.Questions;
        }

        public void Update(Question item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
