using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CourseModel
    {
        public int CourseID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StudentsMaxQuantity { get; set; }
        public int MaxScore { get; set; }
        public int MinRequiredScore { get; set; }
        public TeacherModel Creator { get; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; }
        public int DurationInDays { get; set; }
        public List<LectionModel> Lections { get; set; } = new List<LectionModel>();
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}