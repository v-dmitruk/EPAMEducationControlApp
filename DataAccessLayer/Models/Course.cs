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
        //[ForeignKey("TeacherID")]
        public Teacher Creator { get; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; }
        [Required]
        public int DurationInDays { get; set; }
        //[ForeignKey("LectionID")]
        public List<Lection> Lections { get; set; }
        //[ForeignKey("StudentID")]
        public List<Student> Students { get; set; }
        //[ForeignKey("TestID")]
        public List<Test> Tests { get; set; }
        //public List<TestResult> TestResults { get; set; }
        //public List<LectionResult> LectionResults { get; set; }
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
            Lections = new List<Lection>();
            Students = new List<Student>();
            Tests = new List<Test>();
            //TestResults = new List<TestResult>();
            //LectionResults = new List<LectionResult>();
        }
    }
}