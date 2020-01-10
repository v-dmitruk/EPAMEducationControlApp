using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Lection
    {
        [Key]
        public int LectionID { get; set; }
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
        public virtual Teacher Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual List<Course> Courses { get; set; } = new List<Course>();
        public virtual List<LectionResult> LectionResults { get; set; } = new List<LectionResult>();
        public virtual List<ScheduledEvent> ScheduledEvents { get; set; } = new List<ScheduledEvent>();
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
        }
        public Lection()
        {

        }
    }

}