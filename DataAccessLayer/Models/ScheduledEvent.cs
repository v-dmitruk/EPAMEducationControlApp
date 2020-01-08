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
        public Course Course { get; set; }
        public Lection Lection { get; set; }
        public Test Test { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //[Required]
        public Teacher Creator { get; }
        public DateTime CreationDate { get; }
        public ScheduledEvent(Course course, Lection lection, Test test, DateTime date, Teacher teacher)
        {
            Course = course;
            Lection = lection;
            Test = test;
            Date = date;
            CreationDate = DateTime.Now;
            Creator = teacher;
        }
    }
}
