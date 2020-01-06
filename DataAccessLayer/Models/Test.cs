using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Test
    {
        [Key]
        public int TestID { get; }
        //[ForeignKey("TeacherID")]
        public Teacher Creator { get; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public DateTime CreationDate { get; }
        [Required]
        public int MaxMark { get; set; }
        [Required]
        public int Duration { get; set; }
        public List<Course> Courses { get; set; }
        public List<Question> Questions { get; set; }
        public Test(Teacher creator, string name, string description, int maxMark, int duration)
        {
            Creator = creator;
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
            MaxMark = maxMark;
            Duration = duration;
            Courses = new List<Course>();
            Questions = new List<Question>();
        }
    }
}