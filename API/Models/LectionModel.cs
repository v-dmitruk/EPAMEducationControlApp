using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LectionModel
    {
        [Required]
        public int LectionID { get; set; }
        public string LectionType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LectionBody { get; set; }
        public int MaxMark { get; set; }
        public bool AdditionalMarkIsAvailable { get; set; }
        public TeacherModel Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
        public DateTime? Date { get; set; }
        public LectionModel()
        {

        }
    }
}