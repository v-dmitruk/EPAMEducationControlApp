using API.Models;
using AutoMapper;
using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Infrastructure
{

        public class MapperProfile : AutoMapper.Profile
        {
            public MapperProfile()
            {
                CreateMap<CourseDTO, CourseModel>().ReverseMap();
                CreateMap<LectionDTO, LectionModel>().ReverseMap();
                CreateMap<LectionResultDTO, LectionResultModel>().ReverseMap();
                CreateMap<QuestionDTO, QuestionModel>().ReverseMap();
                CreateMap<ScheduledEventDTO, ScheduledEventModule>().ReverseMap();
                CreateMap<StudentDTO, StudentModel>().ReverseMap();
                CreateMap<TeacherDTO, TeacherModel>().ReverseMap();
                CreateMap<TestDTO, TestModel>().ReverseMap();
                CreateMap<TestResultDTO, TestResultModel>().ReverseMap();

            }

            public static MapperConfiguration Configured()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MapperProfile>();
                });
                return config;
            }
        }
    
}