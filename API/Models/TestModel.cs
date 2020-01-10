using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class TestModel
    {
        public TestModel()
        {
        }

        public int TestID { get; set; }
        public TeacherModel Creator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int MaxMark { get; set; }
        public int Duration { get; set; }
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
        public DateTime? Date { get; set; }
    }
}