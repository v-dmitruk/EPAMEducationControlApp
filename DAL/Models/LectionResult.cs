namespace DAL.Models
{
    public class LectionResult
    {
        public int LectionResultID { get; }
        public Lection Lection { get; }
        public Student Student { get; }
        public int Mark { get; set; }
        public int AdditionalMark { get; set; }
        public LectionResult(Lection lection, Student student, int mark, int addMark)
        {
            Lection = lection;
            Student = student;
            Mark = mark;
            AdditionalMark = addMark;
        }
    }
}