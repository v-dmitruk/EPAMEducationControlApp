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
    public class PerformanceService : IPerformanceService
    {
        Mapper map = new Mapper(MapperProfile.Configured());
        IUnitOfWork db { get; set; }

        public void DeleteLectionResult(int lectionResultID)
        {
            db.LectionResults.Delete(lectionResultID);
            db.Save();
        }

        public void DeleteTestResult(int testResultID)
        {
            db.LectionResults.Delete(testResultID);
            db.Save();
        }

        public IEnumerable<CourseDTO> GetArchievedAndActiveCourses(int studentID)
        {
            Student student = db.Students.Get(studentID);
            IEnumerable<Course> courses = student.Courses;
            List<CourseDTO> result = map.Map<List<CourseDTO>>(courses);
            return result;
        }

        public LectionResultDTO GetLectionResult(int lectionResultID)
        {
            LectionResult lectionResult = db.LectionResults.Get(lectionResultID);
            LectionResultDTO result = map.Map<LectionResultDTO>(lectionResult);
            return result;
        }

        public IEnumerable<LectionResultDTO> GetLectionResultsForCourse(int courseID, int studentID)
        {
            Student student = db.Students.Get(studentID);
            IEnumerable<LectionResult> found = student.LectionResults.Where(x => x.Course.CourseID == courseID);
            List<LectionResultDTO> result = map.Map<List<LectionResultDTO>>(found);
            return result;
        }

        public TestResultDTO GetTestResult(int testResultID)
        {
            TestResult testResult = db.TestResults.Get(testResultID);
            TestResultDTO result = map.Map<TestResultDTO>(testResult);
            return result;
        }

        public IEnumerable<TestResultDTO> GetTestResultsForCourse(int courseID, int studentID)
        {
            Student student = db.Students.Get(studentID);
            IEnumerable<TestResult> found = student.TestResults.Where(x => x.Course.CourseID == courseID);
            List<TestResultDTO> result = map.Map<List<TestResultDTO>>(found);
            return result;
        }
    }
}
