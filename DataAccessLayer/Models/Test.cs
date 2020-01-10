using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Test
    {
        [Key]
        public int TestID { get; set; }
        public virtual Teacher Creator { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public int MaxMark { get; set; }
        [Required]
        public int Duration { get; set; }
        public virtual List<TestResult> TestResults { get; set; } = new List<TestResult>();
        public virtual List<Course> Courses { get; set; } = new List<Course>();
        public virtual List<Question> Questions { get; set; } = new List<Question>();
        public virtual List<ScheduledEvent> ScheduledEvents { get; set; } = new List<ScheduledEvent>();
        public Test(Teacher creator, string name, string description, int maxMark, int duration)
        {
            Creator = creator;
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
            MaxMark = maxMark;
            Duration = duration;
        }
        public Test()
        {

        }
    }
}