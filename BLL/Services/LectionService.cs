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
            LectionResult editedLectionResult = map.Map<LectionResult>(lectionResult);
            db.LectionResults.Update(editedLectionResult);
            db.Save();
        }

        public void EditLection(LectionDTO lection)
        {
            Lection editedLection = map.Map<Lection>(lection);
            db.Lections.Update(editedLection);
            db.Save();
        }

        public IEnumerable<LectionDTO> GetActiveByDate(int userID, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LectionDTO> GetActiveByName(int userID, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LectionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LectionDTO> GetAllActive(int userID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LectionResultDTO> GetAllArchieved(int userID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LectionResultDTO> GetArchievedByDate(int userID, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LectionResultDTO> GetArchievedByName(int userID, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LectionDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
