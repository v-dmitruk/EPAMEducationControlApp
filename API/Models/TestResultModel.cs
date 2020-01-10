using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class TestResultModel
    {
        public int TestResultID { get; }
        public TestModel Test { get; }
        public StudentModel Student { get; }
        public int Mark { get; set; }
        public DateTime PassDate { get; }
        public CourseModel Course { get; }
    }
}