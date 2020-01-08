using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class LectionResult
    {
        [Key, Required]
        public int LectionResultID { get; }
        public Lection Lection { get; }
        public Student Student { get; }
        [Required]
        public int Mark { get; set; }
        [Required]
        public int AdditionalMark { get; set; }
        [Required]
        public DateTime Date { get; }
        public Course Course { get; }
        public bool IsVisited { get; set; }
        public LectionResult(Lection lection, Student student, int mark, int addMark, DateTime date, Course course, bool visited)
        {
            Lection = lection;
            Student = student;
            Mark = mark;
            AdditionalMark = addMark;
            Date = date;
            Course = course;
            IsVisited = visited;
        }
    }
}