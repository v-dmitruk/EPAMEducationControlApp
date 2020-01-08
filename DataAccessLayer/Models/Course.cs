using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Course
    {
        [Key, Required]
        public int CourseID { get; }
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
        public Teacher Creator { get; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; }
        [Required]
        public int DurationInDays { get; set; }
        public List<Lection> Lections { get; set; } = new List<Lection>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Test> Tests { get; set; } = new List<Test>();
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
    }
}