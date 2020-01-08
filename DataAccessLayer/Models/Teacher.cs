using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Teacher
    {
        [Key, Required]
        public int TeacherID { get; }
        public int UserID { get; private set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public List<Question> CreatedQuestions { get; set; } = new List<Question>();
        public List<Test> CreatedTests { get; set; } = new List<Test>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Lection> CreatedLections { get; set; } = new List<Lection>();
        public Teacher(int userID, string name, string lastName, string description, DateTime birthDate)
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
    }
}
