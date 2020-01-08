using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.DTOModels;

namespace BLL.Services
{
    class CourseService : ICourseService
    {
        Mapper map = new Mapper(MapperProfile.Configured());
        IUnitOfWork db { get; set; }

        public CourseService(IUnitOfWork uow)
        {
            db = uow;
        }

        public int CalculateStudentCoursePerformance(int studentID, CourseDTO course)
        {
            throw new NotImplementedException();
        }

        public int CalculateUserCoursePerformance(int userID, CourseDTO course)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(CourseDTO course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetActiveForUser(int userID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetAllArchived(DateTime timePoint)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetArchivedForUser(int userID, DateTime timePoint)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetByDate(int userID, DateTime timePoint)
        {
            throw new NotImplementedException();
        }

        public CourseDTO GetByID(int courseID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetByName(string searchedName)
        {
            throw new NotImplementedException();
        }

        public void StudentSignOut(int userID, CourseDTO course)
        {
            throw new NotImplementedException();
        }

        public void StudentSignUp(int userID, CourseDTO course)
        {
            throw new NotImplementedException();
        }
    }
}
