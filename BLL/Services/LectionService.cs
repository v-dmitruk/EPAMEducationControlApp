using AutoMapper;
using BLL.DTOModels;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LectionService : ILectionService
    {

        Mapper map = new Mapper(MapperProfile.Configured());
        IUnitOfWork db { get; set; }

        public LectionService(IUnitOfWork uow)
        {
            db = uow;
        }
        public void CreateLection(LectionDTO lection)
        {
            Lection newLection = map.Map<Lection>(lection);
            db.Lections.Add(newLection);
            db.Save();
        }

        public void DeleteLection(LectionDTO lection)
        {
            db.Lections.Delete(lection.LectionID);
            db.Save();
        }

        public void DeleteScheduledLection(LectionDTO lection, CourseDTO course)
        {
            ScheduledEvent scheduledLection = db.ScheduledEvents.Find(x => x.Lection.LectionID == lection.LectionID && x.Course.CourseID == course.CourseID).FirstOrDefault();
            db.ScheduledEvents.Delete(scheduledLection.ScheduledEventID);
            db.Save();     
        }

        public void EditArchievedLection(LectionResultDTO lectionResult)
        {
            LectionResult editedLectionResult = db.LectionResults.Get(lectionResult.LectionResultID);
            map.Map(lectionResult, editedLectionResult);
            db.LectionResults.Update(editedLectionResult);
            db.Save();
        }

        public void EditLection(LectionDTO lection)
        {
            Lection editedLection = db.Lections.Get(lection.LectionID);
            map.Map(lection, editedLection);
            db.Lections.Update(editedLection);
            db.Save();
        }

        public IEnumerable<LectionDTO> GetActiveByDate(int userID, DateTime date)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            List<Lection> activeLections = new List<Lection>();
            IEnumerable<Course> activeCourses = student.Courses.Where(x => x.StartDate.AddDays(x.DurationInDays).Date >= date.Date);
            foreach (Course item in activeCourses)
            {
                foreach (Lection lec in item.Lections)
                {
                    Lection lect = db.ScheduledEvents.Find(x => x.Course.CourseID == item.CourseID && x.Lection.LectionID == lec.LectionID && x.Date >= date).FirstOrDefault().Lection;
                    if (lect != null)
                        activeLections.Add(lect); 
                }
            }
            List<LectionDTO> result = map.Map<List<LectionDTO>>(activeLections);
            return result;
        }

        public IEnumerable<LectionDTO> GetActiveByName(int userID, string name)
        {
            List<LectionDTO> activeLections = this.GetActiveByDate(userID, DateTime.Now).ToList();
            return activeLections.Where(x => x.Name.Contains(name));
        }

        public IEnumerable<LectionDTO> GetAll()
        {
            IEnumerable <Lection> lections = db.Lections.GetAll();
            IEnumerable<LectionDTO> result = map.Map<IEnumerable<LectionDTO>>(lections);
            return result;
        }

        public IEnumerable<LectionDTO> GetAllActive(int userID)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            List<Lection> activeLections = new List<Lection>();
            IEnumerable<Course> activeCourses = student.Courses.Where(x => x.StartDate.AddDays(x.DurationInDays).Date >= DateTime.Now.Date);
            foreach (Course item in activeCourses)
            {
                foreach (Lection lec in item.Lections)
                {
                    Lection lect = db.ScheduledEvents.Find(x => x.Course.CourseID == item.CourseID && x.Lection.LectionID == lec.LectionID && x.Date >= DateTime.Now.Date).FirstOrDefault().Lection;
                    if (lect != null)
                        activeLections.Add(lect);
                }
            }
            List<LectionDTO> result = map.Map<List<LectionDTO>>(activeLections);
            return result;
        }

        public IEnumerable<LectionResultDTO> GetAllArchieved()
        {
            List <LectionResultDTO> result = map.Map<List<LectionResultDTO>>(db.LectionResults.GetAll());
            return result;
        }

        public IEnumerable<LectionResultDTO> GetArchievedByDate(int userID, DateTime date)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            IEnumerable<LectionResult> found = student.LectionResults.Where(x => x.Date.Date == date.Date);
            List<LectionResultDTO> result = map.Map<List<LectionResultDTO>>(found);
            return result;
        }

        public IEnumerable<LectionResultDTO> GetArchievedByName(int userID, string name)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            IEnumerable<LectionResult> found = student.LectionResults.Where(x => x.Lection.Name.Contains(name));
            List<LectionResultDTO> result = map.Map<List<LectionResultDTO>>(found);
            return result;
        }

        public LectionDTO GetByID(int lectionID)
        {
            Lection lection = db.Lections.Get(lectionID);
            LectionDTO result = map.Map<LectionDTO>(lection);
            return result;
        }

        public IEnumerable<LectionDTO> GetByName(string name)
        {
            IEnumerable<Lection> found = db.Lections.Find(x => x.Name.Contains(name));
            IEnumerable<LectionDTO> result = map.Map<IEnumerable<LectionDTO>>(found);
            return result;
        }
    }
}
