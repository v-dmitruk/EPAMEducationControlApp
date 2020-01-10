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
    public class StudentService : IStudentService
    {
        Mapper map = new Mapper(MapperProfile.Configured());
        IUnitOfWork db { get; set; }
        public StudentService(IUnitOfWork uow)
        {
            db = uow;
        }
        public void AddStudent(StudentDTO student)
        {
            Student newStudent = map.Map<Student>(student);
            db.Students.Add(newStudent);
            db.Save();
        }
        public void CheckRegistered(string name, string lastName, DateTime birthDay, int userID)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int studentID)
        {
            db.Students.Delete(studentID);
            db.Save();
        }

        public void EditStudent(StudentDTO student)
        {
            Student editedStudent = db.Students.Get(student.StudentID);
            map.Map(student, editedStudent);
            db.Students.Update(editedStudent);
            db.Save();
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            IEnumerable<Student> students = db.Students.GetAll();
            IEnumerable<StudentDTO> result = map.Map<IEnumerable<StudentDTO>>(students);
            return result;
        }

        public StudentDTO GetBestOnCourse(int courseID)
        {
            //Course course = db.Courses.Get(courseID);
            //Student student = course.Students.Where();
            //StudentDTO result = map.Map<StudentDTO>(student);
            //return result;
            throw new NotImplementedException();
        }

        public IEnumerable<StudentDTO> GetByBirthDayDate(DateTime birthDay)
        {
            IEnumerable<Student> students = db.Students.Find(x => x.BirthDate.Date == birthDay.Date);
            IEnumerable<StudentDTO> result = map.Map<IEnumerable<StudentDTO>>(students);
            return result;
        }

        public IEnumerable<StudentDTO> GetByBirthYear(DateTime birthYear)
        {
            IEnumerable<Student> students = db.Students.Find(x => x.BirthDate.Year == birthYear.Year);
            IEnumerable<StudentDTO> result = map.Map<IEnumerable<StudentDTO>>(students);
            return result;
        }

        public IEnumerable<StudentDTO> GetByCourseID(int courseID)
        {
            Course course = db.Courses.Get(courseID);
            IEnumerable<Student> students = course.Students;
            IEnumerable<StudentDTO> result = map.Map<IEnumerable<StudentDTO>>(students);
            return result;
        }

        public StudentDTO GetByID(int id)
        {
            Student student = db.Students.Get(id);
            StudentDTO result = map.Map<StudentDTO>(student);
            return result;
        }

        public IEnumerable<StudentDTO> GetByName(string name)
        {
            IEnumerable<Student> students = db.Students.Find(x => x.Name.Contains(name));
            IEnumerable<StudentDTO> result = map.Map<IEnumerable<StudentDTO>>(students);
            return result;
        }

        public IEnumerable<StudentDTO> GetBySeacrhString(string searchString)
        {
            IEnumerable<Student> students = db.Students.Find(x => (x.Name + x.LastName + x.Description).Contains(searchString));
            IEnumerable<StudentDTO> result = map.Map<IEnumerable<StudentDTO>>(students);
            return result;
        }
    }
}
