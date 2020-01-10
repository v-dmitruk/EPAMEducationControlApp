using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class TestResult
    {
        [Key]
        public int TestResultID { get; set; }
        public virtual Test Test { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        public int Mark { get; set; }
        [Required]
        public DateTime PassDate { get; set; }
        public virtual Course Course { get; set; }
        public TestResult(Test test, Student student, int mark, Course course)
        {
            Test = test;
            Student = student;
            Mark = mark;
            PassDate = DateTime.Now;
            Course = course;
        }
        public TestResult()
        {

        }
    }
}