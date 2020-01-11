using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ScheduledEventModule
    {
        public ScheduledEventModule()
        {
        }
        [System.ComponentModel.DataAnnotations.Required]
        public int ScheduledEventID { get; set; }
        public CourseModel Course { get; set; }
        public LectionModel Lection { get; set; }
        public TestModel Test { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }

    }
}