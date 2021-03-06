﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public virtual Teacher Creator { get; set; }
        [Required, MaxLength(50)]
        public string Category { get; set; }
        public DateTime CreationDate { get; set; }
        [Required, MaxLength(2000)]
        public string QuestionBody { get; set; }
        [MaxLength(2000)]
        public string Answer1 { get; set; }
        [MaxLength(2000)]
        public string Answer2 { get; set; }
        [MaxLength(2000)]
        public string Answer3 { get; set; }
        [MaxLength(2000)]
        public string Answer4 { get; set; }
        [Required]
        public int RightAnswer { get; set; }
        public Question(Teacher creator, string questionBody, string answer1, string answer2, string answer3, string answer4, int rightAnswer, string category)
        {
            Creator = creator;
            CreationDate = DateTime.Now;
            QuestionBody = questionBody;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
            RightAnswer = rightAnswer;
            Category = category;
        }
        public Question()
        {
        }
    }
}