using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public List<LectionResultDTO> LectionResults { get; set; } = new List<LectionResultDTO>();
        public List<TestResultDTO> TestResults { get; set; } = new List<TestResultDTO>();
        public StudentDTO()
        {

        }
        public void UserRegistered(int userID)
        {
            UserID = userID;
        }
    }
}
