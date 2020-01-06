using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class ScheduledEvent
    {
        [Key, Required]
        public int ScheduledEventID;
        //[ForeignKey("CourseID"), Required]
        public Course Course { get; set; }
        //[ForeignKey("LectionID")]
        public Lection Lection { get; set; }
        //[ForeignKey("TestID")]
        public Test Test { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; }
        public ScheduledEvent(Course course, Lection lection, Test test, DateTime date)
        {
            Course = course;
            Lection = lection;
            Test = test;
            Date = date;
            CreationDate = DateTime.Now;
        }
    }
}
