using AutoMapper;
using StudentManagement.API.Entities;
using StudentManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdateDto, Student>();
            CreateMap<Course, CourseDto>();
            CreateMap<Section, SectionDto>();
        }
    }
}
