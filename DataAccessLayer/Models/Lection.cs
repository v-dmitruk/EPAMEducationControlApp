using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Lection
    {
        [Required, Key]
        public int LectionID { get; }
        [MaxLength(20), Required]
        public string LectionType { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
        [MaxLength(300), Required]
        public string Description { get; set; }
        [MaxLength(2000)]
        public string LectionBody { get; set; }
        [Required]
        public int MaxMark { get; set; }
        [Required]
        public bool AdditionalMarkIsAvailable { get; set; }
        //[ForeignKey("TeacherID")]
        public Teacher Creator { get; }
        public DateTime CreationDate { get; }
        public List<Course> Courses { get; set; }
        //public List<LectionResult> LectionResults { get; set; }
        public Lection(string type, string name, string description, string body, int maxMark, bool availability, Teacher creator)
        {
            LectionType = type;
            Name = name;
            Description = description;
            LectionBody = body;
            MaxMark = maxMark;
            AdditionalMarkIsAvailable = availability;
            Creator = creator;
            CreationDate = DateTime.Now;
            Courses = new List<Course>();
            //LectionResults = new List<LectionResult>();
        }
    }

}