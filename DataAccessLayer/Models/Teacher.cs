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
        //[ForeignKey("QuestionID")]
        public List<Question> CreatedQuestions { get; set; }
        //[ForeignKey("TestID")]
        public List<Test> CreatedTests { get; set; }
        //[ForeignKey("CourseID")]
        public List<Course> Courses { get; set; }
        //[ForeignKey("LectionID")]
        public List<Lection> CreatedLections { get; set; }
        public Teacher(int userID, string name, string lastName, string description, DateTime birthDate)
        {
            UserID = userID;
            Name = name;
            LastName = lastName;
            Description = description;
            BirthDate = birthDate;
            CreatedQuestions = new List<Question>();
            CreatedTests = new List<Test>();
            Courses = new List<Course>();
            CreatedLections = new List<Lection>();
        }
        public void UserRegistered(int userID)
        {
            UserID = userID;
        }
    }
}
