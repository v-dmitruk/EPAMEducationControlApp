using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class TestResult
    {
        [Key]
        public int TestResultID { get; }
        //[ForeignKey("TestID")]
        public Test Test { get; }
        //[ForeignKey("StudentID"), Required]
        public Student Student { get; }
        [Required]
        public int Mark { get; set; }
        [Required]
        public DateTime PassDate { get; }
        //[ForeignKey, Required]
        public Course Course { get; }
        public TestResult(Test test, Student student, int mark, Course course)
        {
            Test = test;
            Student = student;
            Mark = mark;
            PassDate = DateTime.Now;
            Course = course;
        }
    }
}