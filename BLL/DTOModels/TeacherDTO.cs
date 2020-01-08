using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class TeacherDTO
    {
        public int TeacherID { get; }
        public int UserID { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public List<QuestionDTO> CreatedQuestions { get; set; } = new List<QuestionDTO>();
        public List<TestDTO> CreatedTests { get; set; } = new List<TestDTO>();
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public List<LectionDTO> CreatedLections { get; set; } = new List<LectionDTO>();
        public TeacherDTO(int userID, string name, string lastName, string description, DateTime birthDate)
        {
            UserID = userID;
            Name = name;
            LastName = lastName;
            Description = description;
            BirthDate = birthDate;
        }
        public void UserRegistered(int userID)
        {
            UserID = userID;
        }

    }
}
