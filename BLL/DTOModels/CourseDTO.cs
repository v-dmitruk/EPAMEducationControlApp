﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StudentsMaxQuantity { get; set; }
        public int MaxScore { get; set; }
        public int MinRequiredScore { get; set; }
        public TeacherDTO Creator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int DurationInDays { get; set; }
        public List<LectionDTO> Lections { get; set; } = new List<LectionDTO>(); 
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
        public List<TestDTO> Tests { get; set; } = new List<TestDTO>();

        public CourseDTO()
        {

        }
    }
}
