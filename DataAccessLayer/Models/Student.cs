using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public int UserID { get; set; }
        [Required, MaxLength(40)]
        public string Name { get; set; }
        [Required, MaxLength(40)]
        public string LastName { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public virtual List<Course> Courses { get; set; } = new List<Course>();
        public virtual List<LectionResult> LectionResults { get; set; } = new List<LectionResult>();
        public virtual List<TestResult> TestResults { get; set; } = new List<TestResult>();
        public Student(int userID, string name, string lastName, string description, DateTime birthDate)
        {
            UserID = userID;
            Name = name;
            LastName = lastName;
            Description = description;
            BirthDate = birthDate;
        }
        public void UserRegistered(int userID)
        {
            UserID = userID;
        }
        public Student()
        {

        }
    }
}
