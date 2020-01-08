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
using DAL.Models;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        Mapper map = new Mapper(MapperProfile.Configured());
        IUnitOfWork db { get; set; }

        public CourseService(IUnitOfWork uow)
        {
            db = uow;
        }

        public int CalculateStudentCoursePerformance(int studentID, CourseDTO course)
        {
            Student student = db.Students.Get(studentID);
            int studentPerformance = 0;
            List<LectionResult> lectionsResults = student.LectionResults.Where(x => x.Course.CourseID == course.CourseID).ToList();
            List<TestResult> testResults = student.TestResults.Where(x => x.Course.CourseID == course.CourseID).ToList();
            foreach (LectionResult item in lectionsResults)
            {
                studentPerformance += item.Mark;
            }
            foreach (TestResult item in testResults)
            {
                studentPerformance += item.Mark;
            }
            return studentPerformance;
        }

        public int CalculateUserCoursePerformance(int userID, CourseDTO course)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            int studentPerformance = 0;
            List<LectionResult> lectionsResults = student.LectionResults.Where(x => x.Course.CourseID == course.CourseID).ToList();
            List<TestResult> testResults = student.TestResults.Where(x => x.Course.CourseID == course.CourseID).ToList();
            foreach (LectionResult item in lectionsResults)
            {
                studentPerformance += item.Mark;
            }
            foreach (TestResult item in testResults)
            {
                studentPerformance += item.Mark;
            }
            return studentPerformance;
        }

        public void DeleteCourse(CourseDTO course)
        {
            db.Courses.Delete(course.CourseID);
            db.Save();
        }

        public IEnumerable<CourseDTO> GetActiveForUser(int userID)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            List<Course> activeCourses = student.Courses.Where(x => (x.StartDate.AddDays(x.DurationInDays)) > DateTime.Now).ToList();
            List<CourseDTO> result = map.Map<List<CourseDTO>>(activeCourses);
            return result;
        }

        public IEnumerable<CourseDTO> GetAllActive()
        {
            IEnumerable<Course> courses = db.Courses.GetAll().Where(x => (x.StartDate.AddDays(x.DurationInDays)) > DateTime.Now);
            List<CourseDTO> result = map.Map<List<CourseDTO>>(courses);
            return result;
        }

        public IEnumerable<CourseDTO> GetAllArchived(DateTime timePoint)
        {
            IEnumerable<Course> courses = db.Courses.GetAll().Where(x => (x.StartDate.AddDays(x.DurationInDays)) > timePoint);
            List<CourseDTO> result = map.Map<List<CourseDTO>>(courses);
            return result;
        }

        public IEnumerable<CourseDTO> GetArchivedForUser(int userID, DateTime timePoint)
        {
            IEnumerable<Course> courses = db.Courses.GetAll().Where(x => (x.StartDate.AddDays(x.DurationInDays)) <= timePoint);
            List<CourseDTO> result = map.Map<List<CourseDTO>>(courses);
            return result;
        }

        public IEnumerable<CourseDTO> GetByDate(int studentID, DateTime timePoint)
        {
            Student student = db.Students.Find(x => x.StudentID == studentID).FirstOrDefault();
            List<Course> foundCourses = student.Courses.Where(x => x.StartDate.Date == timePoint.Date).ToList();
            List<CourseDTO> result = map.Map<List<CourseDTO>>(foundCourses);
            return result;
        }

        public CourseDTO GetByID(int courseID)
        {
            Course course = db.Courses.Get(courseID);
            return map.Map<CourseDTO>(course);
        }

        public IEnumerable<CourseDTO> GetByName(int studentID, string searchedName)
        {
            Student student = db.Students.Find(x => x.StudentID == studentID).FirstOrDefault();
            List<Course> foundCourses = student.Courses.Where(x => x.Name.Contains(searchedName)).ToList();
            List<CourseDTO> result = map.Map<List<CourseDTO>>(foundCourses);
            return result;
        }

        public IEnumerable<CourseDTO> GetByName(string searchedName)
        {
            List<Course> foundCourses = db.Courses.Find(x => x.Name.Contains(searchedName)).ToList();
            List<CourseDTO> result = map.Map<List<CourseDTO>>(foundCourses);
            return result;
        }

        public void StudentSignOut(int userID, CourseDTO course)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            Course dbcourse = db.Courses.Get(course.CourseID);
            student.Courses.Remove(dbcourse);
            dbcourse.Students.Remove(student);
            db.Save();
        }

        public void StudentSignUp(int userID, CourseDTO course)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            Course dbcourse = db.Courses.Get(course.CourseID);
            if (student.Courses.Where(x => x.CourseID == dbcourse.CourseID).Count() > 0)
            {
                return;
            }
            if (dbcourse.Students.Count() >= dbcourse.StudentsMaxQuantity)
            {
                student.Courses.Add(dbcourse);
                dbcourse.Students.Add(student);
                db.Save();
            }
            else
            {
                //throw exception
            }
        }

        public void EditCourse(CourseDTO course)
        {
            //Course editedCourse = db.Courses.Get(course.CourseID);
            Course editedCourse = map.Map<Course>(course);
            db.Courses.Update(editedCourse);
            db.Save();
        }

        public void CreateCourse(CourseDTO course)
        {
            Course newCourse = map.Map<Course>(course);
            db.Courses.Add(newCourse);
            db.Save();
        }
    }
}
