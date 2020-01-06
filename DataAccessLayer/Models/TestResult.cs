namespace DAL.Models
{
    public class TestResult
    {
        public int TestResultID { get; }
        public Test Test { get; }
        public Student Student { get; }
        public int Mark { get; set; }
        public TestResult(Test test, Student student, int mark)
        {
            Test = test;
            Student = student;
            Mark = mark;
        }
    }
}