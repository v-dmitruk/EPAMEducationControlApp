using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class TeacherModel
    {
        public TeacherModel()
        {
        }

        public int TeacherID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public List<QuestionModel> CreatedQuestions { get; set; } = new List<QuestionModel>();
        public List<TestModel> CreatedTests { get; set; } = new List<TestModel>();
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
        public List<LectionModel> CreatedLections { get; set; } = new List<LectionModel>();
    }
}