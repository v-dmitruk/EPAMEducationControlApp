using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class TestResultModel
    {
        public TestResultModel()
        {
        }
        [System.ComponentModel.DataAnnotations.Required]
        public int TestResultID { get; set; }
        public TestModel Test { get; set; }
        public StudentModel Student { get; set; }
        public int Mark { get; set; }
        public DateTime PassDate { get; set; }
        public CourseModel Course { get; set; }
    }
}