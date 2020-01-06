using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Course
    {
        public int CourseID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StudentsMaxQuantity { get; set; }
        public int MaxScore { get; set; }
        public int MinScore { get; set; }
        public Teacher Creator { get; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; }
        public int DurationInDays { get; set; }
        public List<Lection> Lections { get; set; }
        public List<Student> Students { get; set; }
        public List<Test> Tests { get; set; }
        public Course(string name, string description, int studensMaxQuantity, int maxScore, int minScore, Teacher creator, DateTime startDate, int duration)
        {
            CreationDate = DateTime.Now;
            Creator = creator;
            Name = name;
            Description = description;
            StudentsMaxQuantity = studensMaxQuantity;
            MaxScore = maxScore;
            MinScore = minScore;
            StartDate = startDate;
            DurationInDays = duration;
            Lections = new List<Lection>();
            Students = new List<Student>();
            Tests = new List<Test>();
        }
    }
}