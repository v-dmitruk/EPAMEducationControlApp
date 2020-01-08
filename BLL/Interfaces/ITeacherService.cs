using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<TeacherDTO> GetAll();
        IEnumerable<TeacherDTO> GetByCourseName(string name);
        IEnumerable<TeacherDTO> GetByName(string name);
        TeacherDTO GetByID(int id);
        IEnumerable<TeacherDTO> GetByBirthDayDate(DateTime birthDay);
        IEnumerable<TeacherDTO> GetByBirthYear(DateTime birthYear);
        TeacherDTO GetByMostQuestions();
        TeacherDTO GetByMostTest();
        TeacherDTO GetByMostCourses();
        TeacherDTO GetByMostLections();
        int CreatedCoursesCount(int teacherID);
        int CreatedTestCount(int teacherID);
        int CreatedQuestionsCount(int teacherID);
        int CreatedLectionsCount(int teacherID);
        void EditTeacher(TeacherDTO teacher);
        void AddTeacher(TeacherDTO teacher);
        void DeleteTeacher(int teacherID);
        void CheckRegistered(string name, string lastName, DateTime birthDay, int userID);
    }
}
