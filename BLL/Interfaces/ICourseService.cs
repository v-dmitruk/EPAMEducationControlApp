using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICourseService
    {
        void StudentSignUp(int userID, CourseDTO course);
        void StudentSignOut(int userID, CourseDTO course);
        int CalculateUserCoursePerformance(int userID, CourseDTO course);
        int CalculateStudentCoursePerformance(int studentID, CourseDTO course);
        void DeleteCourse(CourseDTO course);
        IEnumerable<CourseDTO> GetAllActive();
        IEnumerable<CourseDTO> GetAllArchived(DateTime timePoint);
        IEnumerable<CourseDTO> GetByName(int studentID, string searchedName);
        IEnumerable<CourseDTO> GetActiveForUser(int userID);
        IEnumerable<CourseDTO> GetArchivedForUser(int userID, DateTime timePoint);
        CourseDTO GetByID(int courseID);
        IEnumerable<CourseDTO> GetByDate(int userID, DateTime timePoint);
        IEnumerable<CourseDTO> GetByName(string searchedName);
        void EditCourse(CourseDTO course);
        void CreateCourse(CourseDTO course);
        IEnumerable<CourseDTO> GetAll();
    }
}
