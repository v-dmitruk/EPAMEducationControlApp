using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class StudentModel
    {
        public StudentModel()
        {
        }

        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
        public List<LectionResultModel> LectionResults { get; set; } = new List<LectionResultModel>();
        public List<TestResultModel> TestResults { get; set; } = new List<TestResultModel>();
    }
}