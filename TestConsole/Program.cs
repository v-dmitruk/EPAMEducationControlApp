using BLL.DTOModels;
using BLL.Services;
using DAL.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork db = new UnitOfWork(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DAL.EduDbContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");

            //Student st1 = new Student(1, "Piccolo", "Gokunovich", "Wild fighter", DateTime.Now);
            //db.Students.Add(st1);
            //db.Save();
            Console.WriteLine(db.Students.GetAll().First().StudentID + " " + db.Students.GetAll().First().Name + " " + db.Students.GetAll().First().LastName);

            //Teacher tch1 = new Teacher(2, "Maria", "Ivanovna", "The bestest teacher in Shearwood", DateTime.Now);
            //Course cs1 = new Course("Mathematics", "Easy course", 100, 100, 40, tch1, DateTime.Now, 40);
            //Course cs2 = new Course("Literature", "Hard course", 40, 100, 60, tch1, DateTime.Now, 10);
            //cs1.Creator = tch1;
            //cs2.Creator = tch1;
            //db.Teachers.Add(tch1);
            //db.Save();
            //db.Courses.Add(cs1);            
            //db.Courses.Add(cs2);
            //db.Save();
            List<Course> courses = db.Courses.GetAll().ToList();
            foreach (Course item in courses)
            {
                Console.WriteLine(item.Creator.Name);
            }


            BLLUnitOfWork BLLdb = new BLLUnitOfWork(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DAL.EduDbContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");
            TeacherDTO tch2 = BLLdb.TeacherService.GetByID(1);
            Console.WriteLine(tch2.Name);
            foreach (CourseDTO item in tch2.Courses)
            {
                Console.WriteLine(item.Description);
            }
            Console.ReadLine();

            List<CourseDTO> courses2 = BLLdb.CourseService.GetAll().ToList();
            foreach (CourseDTO item in courses2)
            {
                Console.WriteLine(item.Creator.Name);
            }




            Console.ReadLine();
        }
    }
}
