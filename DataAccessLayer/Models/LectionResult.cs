using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class LectionResult
    {
        [Key, Required]
        public int LectionResultID { get; }
        //[ForeignKey("LectionID")]
        public Lection Lection { get; }
        //[Required, ForeignKey("StudentID")]
        public Student Student { get; }
        [Required]
        public int Mark { get; set; }
        [Required]
        public int AdditionalMark { get; set; }
        [Required]
        public DateTime Date { get; }
        public Course Course { get; }
        public LectionResult(Lection lection, Student student, int mark, int addMark, DateTime date, Course course)
        {
            Lection = lection;
            Student = student;
            Mark = mark;
            AdditionalMark = addMark;
            Date = date;
            Course = course;
        }
    }
}