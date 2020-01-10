using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public int UserID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public virtual List<Question> CreatedQuestions { get; set; } = new List<Question>();
        public virtual List<Test> CreatedTests { get; set; } = new List<Test>();
        public virtual List<Course> Courses { get; set; } = new List<Course>();
        public virtual List<Lection> CreatedLections { get; set; } = new List<Lection>();
        public virtual List<ScheduledEvent> ScheduledEvents { get; set; } = new List<ScheduledEvent>();
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
        public Teacher()
        {

        }
    }
}
