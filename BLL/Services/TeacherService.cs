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
    public class TeacherService : ITeacherService
    {
        Mapper map = new Mapper(MapperProfile.Configured());
        IUnitOfWork db { get; set; }
        public TeacherService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void AddTeacher(TeacherDTO teacher)
        {
            Teacher newTeacher = map.Map<Teacher>(teacher);
            db.Teachers.Add(newTeacher);
            db.Save();
        }

        public void CheckRegistered(string name, string lastName, DateTime birthDay, int userID)
        {
            throw new NotImplementedException();
        }

        public int CreatedCoursesCount(int teacherID)
        {
            Teacher teacher = db.Teachers.Get(teacherID);
            return teacher.Courses.Count();
        }

        public int CreatedLectionsCount(int teacherID)
        {
            Teacher teacher = db.Teachers.Get(teacherID);
            return teacher.CreatedLections.Count();
        }

        public int CreatedQuestionsCount(int teacherID)
        {
            Teacher teacher = db.Teachers.Get(teacherID);
            return teacher.CreatedQuestions.Count();
        }

        public int CreatedTestCount(int teacherID)
        {
            Teacher teacher = db.Teachers.Get(teacherID);
            return teacher.CreatedTests.Count();
        }

        public void DeleteTeacher(int teacherID)
        {
            db.Teachers.Delete(teacherID);
            db.Save();
        }

        public void EditTeacher(TeacherDTO teacher)
        {
            Teacher editedTeacher = db.Teachers.Get(teacher.TeacherID);
            map.Map(teacher, editedTeacher);
            db.Teachers.Update(editedTeacher);
            db.Save();
        }

        public IEnumerable<TeacherDTO> GetAll()
        {
            IEnumerable<Teacher> teachers = db.Teachers.GetAll();
            IEnumerable<TeacherDTO> result = map.Map<IEnumerable<TeacherDTO>>(teachers);
            return result;
        }

        public IEnumerable<TeacherDTO> GetByBirthDayDate(DateTime birthDay)
        {
            IEnumerable<Teacher> teachers = db.Teachers.Find(x => x.BirthDate.Date == birthDay.Date);
            IEnumerable<TeacherDTO> result = map.Map<IEnumerable<TeacherDTO>>(teachers);
            return result;
        }

        public IEnumerable<TeacherDTO> GetByBirthYear(DateTime birthYear)
        {
            IEnumerable<Teacher> teachers = db.Teachers.Find(x => x.BirthDate.Year == birthYear.Year);
            IEnumerable<TeacherDTO> result = map.Map<IEnumerable<TeacherDTO>>(teachers);
            return result;
        }

        public IEnumerable<TeacherDTO> GetByCourseName(string name)
        {
            List<Course> foundCourses = db.Courses.Find(x => x.Name.Contains(name)).ToList();
            List<Teacher> foundTeachers = new List<Teacher>();
            foreach (Course item in foundCourses)
            {
                if (item.Name.Contains(name))
                    foundTeachers.Add(item.Creator);
            }
            IEnumerable<TeacherDTO> result = map.Map<IEnumerable<TeacherDTO>>(foundTeachers);
            return result;
        }

        public TeacherDTO GetByID(int id)
        {
            Teacher teacher = db.Teachers.Get(id);
            TeacherDTO result = map.Map<TeacherDTO>(teacher);
            return result;
        }

        public TeacherDTO GetByMostCourses()
        {
            throw new NotImplementedException();
        }

        public TeacherDTO GetByMostLections()
        {
            throw new NotImplementedException();
        }

        public TeacherDTO GetByMostQuestions()
        {
            throw new NotImplementedException();
        }

        public TeacherDTO GetByMostTest()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeacherDTO> GetByName(string name)
        {
            IEnumerable<Teacher> teachers = db.Teachers.Find(x => x.Name.Contains(name));
            IEnumerable<TeacherDTO> result = map.Map<IEnumerable<TeacherDTO>>(teachers);
            return result;
        }
    }
}
