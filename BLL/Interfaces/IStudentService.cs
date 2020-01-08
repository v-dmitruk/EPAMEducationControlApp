using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAll();
        IEnumerable<StudentDTO> GetByCourseName(string name);
        IEnumerable<StudentDTO> GetByName(string name);
        StudentDTO GetByID(int id);
        IEnumerable<StudentDTO> GetByBirthDayDate(DateTime birthDay);
        IEnumerable<StudentDTO> GetByBirthYear(DateTime birthYear);
        StudentDTO GetBestOnCourse(int courseID);
        void EditStudent(StudentDTO student);
        void AddStudent(StudentDTO student);
        void DeleteStudent(int studentID);
        void CheckRegistered(string name, string lastName, DateTime birthDay, int userID);
        IEnumerable<StudentDTO> GetBySeacrhString(string searchString);
    }
}
