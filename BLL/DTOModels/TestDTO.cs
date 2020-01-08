using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class TestDTO
    {
        public int TestID { get; }
        public TeacherDTO Creator { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; }
        public int MaxMark { get; set; }
        public int Duration { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public List<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();
        public DateTime? Date { get; set; }
        public TestDTO(TeacherDTO creator, string name, string description, int maxMark, int duration)
        {
            Creator = creator;
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
            MaxMark = maxMark;
            Duration = duration;
            Date = null;
        }
    }
}
