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
            CreateMap<CourseDTO, DAL.Models.Course>().ReverseMap();
            CreateMap<LectionDTO, DAL.Models.Lection>().ReverseMap();
            CreateMap<LectionResultDTO, DAL.Models.LectionResult>().ReverseMap();
            CreateMap<QuestionDTO, DAL.Models.Question>().ReverseMap();
            CreateMap<ScheduledEventDTO, DAL.Models.ScheduledEvent>().ReverseMap();
            CreateMap<StudentDTO, DAL.Models.Student>().ReverseMap();
            CreateMap<TeacherDTO, DAL.Models.Teacher>().ReverseMap();
            CreateMap<TestDTO, DAL.Models.Test>().ReverseMap();
            CreateMap<TestResultDTO, DAL.Models.TestResult>().ReverseMap();



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
