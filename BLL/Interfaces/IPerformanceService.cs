using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPerformanceService
    {
        IEnumerable<CourseDTO> GetArchievedAndActiveCourses(int studentID);
        IEnumerable<TestResultDTO> GetTestResultsForCourse(int courseID, int studentID);
        IEnumerable<LectionResultDTO> GetLectionResultsForCourse(int courseID, int studentID);
        TestResultDTO GetTestResult(int testResultID);
        LectionResultDTO GetLectionResult(int lectionResultID);
        //TestResult, LectionResult EDIT-methods are in LectionService and TestService
        void DeleteTestResult(int testResultID);
        void DeleteLectionResult(int lectionResultID);
    }
}
