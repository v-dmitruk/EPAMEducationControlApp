using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class LectionResult
    {
        [Key]
        public int LectionResultID { get; set; }
        public virtual Lection Lection { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        public int Mark { get; set; }
        [Required]
        public int AdditionalMark { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public virtual Course Course { get; set; }
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
        public LectionResult()
        {

        }
    }
}