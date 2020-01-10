using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class QuestionModel
    {
        public int QuestionID { get; }
        public TeacherModel Creator { get; }
        public DateTime CreationDate { get; }
        public string QuestionBody { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int RightAnswer { get; set; }
        public string Category { get; set; }
    }
}