using AutoMapper;
using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
        public class MapperProfile : AutoMapper.Profile
        {
            public MapperProfile()
            {
            CreateMap<CourseDTO, DAL.Models.Course>();
            CreateMap<DAL.Models.Course, CourseDTO>();

            CreateMap<LectionDTO, DAL.Models.Lection>();
            CreateMap<DAL.Models.Lection, LectionDTO>();

            CreateMap<LectionResultDTO, DAL.Models.LectionResult>();
            CreateMap<DAL.Models.LectionResult, LectionResultDTO>();

            CreateMap<QuestionDTO, DAL.Models.Question>();
            CreateMap<DAL.Models.Question, QuestionDTO>();

            CreateMap<ScheduledEventDTO, DAL.Models.ScheduledEvent>();
            CreateMap<DAL.Models.ScheduledEvent, ScheduledEventDTO>();

            CreateMap<StudentDTO, DAL.Models.Student>();
            CreateMap<DAL.Models.Student, StudentDTO>();

            CreateMap<TeacherDTO, DAL.Models.Teacher>();
            CreateMap<DAL.Models.Teacher, TeacherDTO>();

            CreateMap<TestDTO, DAL.Models.Test>();
            CreateMap<DAL.Models.Test, TestDTO>();

            CreateMap<TestResultDTO, DAL.Models.TestResult>();
            CreateMap<DAL.Models.TestResult, TestResultDTO>();



            //CreateMap<Category, DAL.Category>()
            //        .ForMember(dest => dest.ID, source => source.MapFrom(map => map.ID))
            //        .ForMember(dest => dest.Name, source => source.MapFrom(map => map.Name))
            //        .ForMember(dest => dest.Description, source => source.MapFrom(map => map.Description))
            //        .ForMember(dest => dest.Products, source => source.MapFrom(map => map.Products));
            //    CreateMap<DAL.Category, Category>()
            //        .ForMember(dest => dest.ID, source => source.MapFrom(map => map.ID))
            //        .ForMember(dest => dest.Name, source => source.MapFrom(map => map.Name))
            //        .ForMember(dest => dest.Description, source => source.MapFrom(map => map.Description))
            //        .ForMember(dest => dest.Products, source => source.MapFrom(map => map.Products));
            //    CreateMap<Provider, DAL.Provider>();
            //    CreateMap<DAL.Provider, Provider>();
            //    CreateMap<Product, DAL.Product>().ForMember(dest => dest.Categories, source => source.MapFrom(map => map.Categories));
            //    CreateMap<DAL.Product, Product>().ForMember(dest => dest.Categories, source => source.MapFrom(map => map.Categories));
            
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
