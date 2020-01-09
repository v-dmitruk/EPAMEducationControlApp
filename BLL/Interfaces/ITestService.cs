using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        IEnumerable<TestDTO> GetAll();
        IEnumerable<TestDTO> GetByName(string name);
        IEnumerable<TestResultDTO> GetAllArchieved(int userID);
        IEnumerable<TestResultDTO> GetArchievedByDate(int userID, DateTime date);
        IEnumerable<TestResultDTO> GetArchievedByName(int userID, string name);
        IEnumerable<TestDTO> GetAllActive(int userID);
        IEnumerable<TestDTO> GetActiveByDate(int userID, DateTime date);
        IEnumerable<TestDTO> GetActiveByName(int userID, string name);
        void EditTest(TestDTO test);
        void DeleteScheduledTest(TestDTO test, CourseDTO course);
        void CreateTest(TestDTO test);
        void DeleteTest(TestDTO test);
        void ChangeArchievedTest(TestResultDTO test);
        TestDTO GetByID(int testID);
    }
}
