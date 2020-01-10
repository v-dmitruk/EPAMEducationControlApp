using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LectionModel
    {
        public int LectionID { get; }
        public string LectionType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LectionBody { get; set; }
        public int MaxMark { get; set; }
        public bool AdditionalMarkIsAvailable { get; set; }
        public TeacherModel Creator { get; }
        public DateTime CreationDate { get; }
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
        public DateTime? Date { get; set; }
    }
}