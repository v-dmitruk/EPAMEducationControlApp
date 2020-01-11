using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class QuestionModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public int QuestionID { get; set; }
        public TeacherModel Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public string QuestionBody { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int RightAnswer { get; set; }
        public string Category { get; set; }
        public QuestionModel()
        {

        }
    }
}