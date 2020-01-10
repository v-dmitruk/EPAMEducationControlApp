using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class ScheduledEvent
    {
        [Key]
        public int ScheduledEventID { get; set; }
        public virtual Course Course { get; set; }
        public virtual Lection Lection { get; set; }
        public virtual Test Test { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //[Required]
        public virtual Teacher Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public ScheduledEvent(Course course, Lection lection, Test test, DateTime date, Teacher teacher)
        {
            Course = course;
            Lection = lection;
            Test = test;
            Date = date;
            CreationDate = DateTime.Now;
            Creator = teacher;
        }
        public ScheduledEvent()
        {

        }
    }
}
