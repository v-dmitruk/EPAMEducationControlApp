using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ScheduledEvent
    {
        public Course Course { get; set; }
        public Lection Lection { get; set; }
        public Test Test { get; set; }
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
