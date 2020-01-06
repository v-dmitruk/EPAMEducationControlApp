using System;

namespace DAL.Models
{
    public class Question
    {
        public int QuestionID { get; }
        public Teacher Creator { get; }
        public DateTime CreationDate { get; }
        public string QuestionBody { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int RightAnswer { get; set; }
        public Question(Teacher creator, string questionBody, string answer1, string answer2, string answer3, string answer4, int rightAnswer)
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