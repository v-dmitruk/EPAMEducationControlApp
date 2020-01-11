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
    public class TestService : ITestService
    {
        Mapper map = new Mapper(MapperProfile.Configured());
        IUnitOfWork db { get; set; }
        public TestService(IUnitOfWork uow)
        {
            db = uow;
        }
        public void ChangeArchievedTest(TestResultDTO test)
        {
            TestResult editedTestResult = db.TestResults.Get(test.TestResultID);
            map.Map(test, editedTestResult);
            db.TestResults.Update(editedTestResult);
            db.Save();
        }

        public void CreateTest(TestDTO test)
        {
            TestResult newTestResult = map.Map<TestResult>(test);
            db.TestResults.Add(newTestResult) ;
            db.Save();
        }

        public void DeleteScheduledTest(TestDTO test, CourseDTO course)
        {
            ScheduledEvent scheduledLection = db.ScheduledEvents.Find(x => x.Test.TestID == test.TestID && x.Course.CourseID == course.CourseID).FirstOrDefault();
            db.ScheduledEvents.Delete(scheduledLection.ScheduledEventID);
            db.Save();
        }

        public void DeleteTest(TestDTO test)
        {
            db.Tests.Delete(test.TestID);
            db.Save();
        }

        public void EditTest(TestDTO test)
        {
            Test editedTest = db.Tests.Get(test.TestID);
            map.Map(test, editedTest);
            db.Tests.Update(editedTest);
            db.Save();
        }

        public IEnumerable<TestDTO> GetActiveByDate(int userID, DateTime date)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            List<Test> activeTests = new List<Test>();
            IEnumerable<Course> activeCourses = student.Courses.Where(x => x.StartDate.AddDays(x.DurationInDays).Date >= date.Date);
            foreach (Course item in activeCourses)
            {
                foreach (Test test in item.Tests)
                {
                    Test test1 = db.ScheduledEvents.Find(x => x.Course.CourseID == item.CourseID && x.Test.TestID == test.TestID && x.Date >= date).FirstOrDefault().Test;
                    if (test1 != null)
                        activeTests.Add(test1);
                }
            }
            List<TestDTO> result = map.Map<List<TestDTO>>(activeTests);
            return result;
        }

        public IEnumerable<TestDTO> GetActiveByName(int userID, string name)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            List<Test> activeTests = new List<Test>();
            IEnumerable<Course> activeCourses = student.Courses.Where(x => x.StartDate.AddDays(x.DurationInDays).Date >= DateTime.Now.Date);
            foreach (Course item in activeCourses)
            {
                foreach (Test test in item.Tests)
                {
                    Test test1 = db.ScheduledEvents.Find(x => x.Course.CourseID == item.CourseID && x.Test.TestID == test.TestID && x.Test.Name.Contains(name)).FirstOrDefault().Test;
                    if (test1 != null)
                        activeTests.Add(test1);
                }
            }
            List<TestDTO> result = map.Map<List<TestDTO>>(activeTests);
            return result;
        }

        public IEnumerable<TestDTO> GetAll()
        {
            IEnumerable<Test> tests = db.Tests.GetAll();
            IEnumerable<TestDTO> result = map.Map<IEnumerable<TestDTO>>(tests);
            return result;
        }

        public IEnumerable<TestDTO> GetAllActive(int userID)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            List<Test> activeTests = new List<Test>();
            IEnumerable<Course> activeCourses = student.Courses.Where(x => x.StartDate.AddDays(x.DurationInDays).Date >= DateTime.Now.Date);
            foreach (Course item in activeCourses)
            {
                foreach (Test test in item.Tests)
                {
                    Test test1 = db.ScheduledEvents.Find(x => x.Course.CourseID == item.CourseID && x.Test.TestID == test.TestID && x.Date >= DateTime.Now.Date).FirstOrDefault().Test;
                    if (test1 != null)
                        activeTests.Add(test1);
                }
            }
            List<TestDTO> result = map.Map<List<TestDTO>>(activeTests);
            return result;
        }

        public IEnumerable<TestResultDTO> GetAllArchieved()
        {
            List<TestResultDTO> result = map.Map<List<TestResultDTO>>(db.TestResults.GetAll());
            return result;
        }

        public IEnumerable<TestResultDTO> GetArchievedByDate(int userID, DateTime date)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            IEnumerable<TestResult> found = student.TestResults.Where(x => x.PassDate.Date == date.Date);
            List<TestResultDTO> result = map.Map<List<TestResultDTO>>(found);
            return result;
        }

        public IEnumerable<TestResultDTO> GetArchievedByName(int userID, string name)
        {
            Student student = db.Students.Find(x => x.UserID == userID).FirstOrDefault();
            IEnumerable<TestResult> found = student.TestResults.Where(x => x.Test.Name.Contains(name));
            List<TestResultDTO> result = map.Map<List<TestResultDTO>>(found);
            return result;
        }

        public TestDTO GetByID(int testID)
        {
            Test test = db.Tests.Get(testID);
            TestDTO result = map.Map<TestDTO>(test);
            return result;
        }

        public IEnumerable<TestDTO> GetByName(string name)
        {
            IEnumerable<Test> found = db.Tests.Find(x => x.Name.Contains(name));
            IEnumerable<TestDTO> result = map.Map<IEnumerable<TestDTO>>(found);
            return result;
        }
    }
}
