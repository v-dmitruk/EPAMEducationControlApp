using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class TestResultDTO
    {
        public int TestResultID { get; }
        public TestDTO Test { get; }
        public StudentDTO Student { get; }
        public int Mark { get; set; }
        public DateTime PassDate { get; }
        public CourseDTO Course { get; }
        public TestResultDTO(TestDTO test, StudentDTO student, int mark, CourseDTO course)
        {
            Test = test;
            Student = student;
            Mark = mark;
            PassDate = DateTime.Now;
            Course = course;
        }
    }
}
