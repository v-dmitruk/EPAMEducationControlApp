using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Student
    {
        //[Key]
        public int StudentID { get; }
        public int UserID { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Course> Courses { get; set; }
        public List<LectionResult> LectionResults { get; set; }
        public List<TestResult> TestResults { get; set; }
        public Student(int userID, string name, string lastName, string description, DateTime birthDate)
        {
            UserID = userID;
            Name = name;
            LastName = lastName;
            Description = description;
            BirthDate = birthDate;
            LectionResults = new List<LectionResult>();
            TestResults = new List<TestResult>();
            Courses = new List<Course>();
        }
        public void UserRegistered(int userID)
        {
            UserID = userID;
        }
    }
}
