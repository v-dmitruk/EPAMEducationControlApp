using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class QuestionDTO
    {
        public int QuestionID { get; }
        public TeacherDTO Creator { get; }
        public DateTime CreationDate { get; }
        public string QuestionBody { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int RightAnswer { get; set; }
        public QuestionDTO(TeacherDTO creator, string questionBody, string answer1, string answer2, string answer3, string answer4, int rightAnswer)
        {
            Creator = creator;
            CreationDate = DateTime.Now;
            QuestionBody = questionBody;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
            RightAnswer = rightAnswer;
        }
    }
}
