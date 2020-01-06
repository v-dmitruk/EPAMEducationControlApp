using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class LectionResultDTO
    {
        public int LectionResultID { get; }
        public LectionDTO Lection { get; }
        public StudentDTO Student { get; }
        public int Mark { get; set; }
        public int AdditionalMark { get; set; }
        public DateTime Date { get; }
        public CourseDTO Course { get; }
        public LectionResultDTO(LectionDTO lection, StudentDTO student, int mark, int addMark, DateTime date, CourseDTO course)
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
