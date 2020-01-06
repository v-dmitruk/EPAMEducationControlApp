using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Teacher
    {
        public int TeacherID { get; }
        public int UserID { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Question> Questions { get; set; }
        public List<Test> Tests { get; set; }
        public List<Course> Courses { get; set; }
        public List<Lection> Lections { get; set; }
        public Teacher(int userID, string name, string lastName, string description, DateTime birthDate)
        {
            UserID = userID;
            Name = name;
            LastName = lastName;
            Description = description;
            BirthDate = birthDate;
            Questions = new List<Question>();
            Tests = new List<Test>();
            Courses = new List<Course>();
            Lections = new List<Lection>();
        }
        public void UserRegistered(int userID)
        {
            UserID = userID;
        }
    }
}
