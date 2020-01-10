using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LectionResultModel
    {
        public int LectionResultID { get; set; }
        public LectionModel Lection { get; set; }
        public StudentModel Student { get; set; }
        public int Mark { get; set; }
        public int AdditionalMark { get; set; }
        public DateTime Date { get; set; }
        public CourseModel Course { get; set; }
        public bool IsVisited { get; set; }
        public LectionResultModel()
        {

        }
    }
}