using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class TestDTO
    {
        public int TestID { get; set; }
        public TeacherDTO Creator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int MaxMark { get; set; }
        public int Duration { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public List<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();
        public DateTime? Date { get; set; }
        public TestDTO()
        {

        }
    }
}
