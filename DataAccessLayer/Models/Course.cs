using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
        [Required, MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        public int StudentsMaxQuantity { get; set; }
        [Required]
        public int MaxScore { get; set; }
        [Required]
        public int MinRequiredScore { get; set; }
        public virtual Teacher Creator { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public int DurationInDays { get; set; }
        public virtual List<Lection> Lections { get; set; } = new List<Lection>();
        public virtual List<Student> Students { get; set; } = new List<Student>();
        public virtual List<Test> Tests { get; set; } = new List<Test>();
        public virtual List<LectionResult> LectionResults { get; set; } = new List<LectionResult>();
        public virtual List<TestResult> TestResults { get; set; } = new List<TestResult>();
        public virtual List<ScheduledEvent> ScheduledEvents { get; set; } = new List<ScheduledEvent>();
        public Course(string name, string description, int studensMaxQuantity, int maxScore, int minScore, Teacher creator, DateTime startDate, int duration)
        {
            CreationDate = DateTime.Now;
            Creator = creator;
            Name = name;
            Description = description;
            StudentsMaxQuantity = studensMaxQuantity;
            MaxScore = maxScore;
            MinRequiredScore = minScore;
            StartDate = startDate;
            DurationInDays = duration;
        }
        public Course()
        {

        }
    }
}