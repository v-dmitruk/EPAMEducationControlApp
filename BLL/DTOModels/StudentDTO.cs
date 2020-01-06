using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class StudentDTO
    {
        public int StudentID { get; }
        public int UserID { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public List<CourseDTO> Courses { get; set; }
        public List<LectionResultDTO> LectionResults { get; set; }
        public List<TestResultDTO> TestResults { get; set; }
        public StudentDTO(int userID, string name, string lastName, string description, DateTime birthDate)
        {
            UserID = userID;
            Name = name;
            LastName = lastName;
            Description = description;
            BirthDate = birthDate;
            LectionResults = new List<LectionResultDTO>();
            TestResults = new List<TestResultDTO>();
            Courses = new List<CourseDTO>();
        }
        public void UserRegistered(int userID)
        {
            UserID = userID;
        }
    }
}
