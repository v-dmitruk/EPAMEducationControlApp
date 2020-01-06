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
    class ScheduledEventRepository : IRepository<ScheduledEvent>
    {
        private EduDBContext _db;
        public ScheduledEventRepository(EduDBContext context)
        {
            this._db = context;
        }
        public void Add(ScheduledEvent item)
        {
            _db.ScheduledEvents.Add(item);
        }

        public void Delete(int id)
        {
            ScheduledEvent scheduledEvent = _db.ScheduledEvents.Find(id);
            if (scheduledEvent != null)
                _db.ScheduledEvents.Remove(scheduledEvent);
        }

        public IEnumerable<ScheduledEvent> Find(Func<ScheduledEvent, bool> item)
        {
            return _db.ScheduledEvents.Where(item).ToList();
        }

        public ScheduledEvent Get(int id)
        {
            return _db.ScheduledEvents.Find(id);
        }

        public IEnumerable<ScheduledEvent> GetAll()
        {
            return _db.ScheduledEvents;
        }

        public void Update(ScheduledEvent item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
