using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LectionResultModel
    {
        public int LectionResultID { get; }
        public LectionModel Lection { get; }
        public StudentModel Student { get; }
        public int Mark { get; set; }
        public int AdditionalMark { get; set; }
        public DateTime Date { get; }
        public CourseModel Course { get; }
        public bool IsVisited { get; set; }
    }
}