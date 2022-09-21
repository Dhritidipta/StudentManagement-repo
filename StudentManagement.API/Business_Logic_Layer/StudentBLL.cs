using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.API.Entities;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;

namespace StudentManagement.API.Business_Logic_Layer
{
    public class StudentBLL : IStudentBLL
    {
        private readonly IStudentDAL _DAL;
        private readonly IMapper _mapper;

        public StudentBLL(IStudentDAL dAL, IMapper mapper)
        {
            _DAL = dAL;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public StudentDto AddStudent(StudentForCreationDto studentCreationDto)
        {
            var studentEntity = _mapper.Map<Student>(studentCreationDto);
            _DAL.AddStudent(studentEntity);
            _DAL.Save();

            return _mapper.Map<StudentDto>(studentEntity);
        }

        public void DeleteStudent(int id)
        {
            var studentFromDAL = _DAL.GetStudent(id);

            if (studentFromDAL == null)
            {
                throw new NullReferenceException("Not found");
            }

            _DAL.DeleteStudent(studentFromDAL);
            _DAL.Save();
        }

        public IEnumerable<CourseDto> GetCourses()
        {
            var coursesFromDAL = _DAL.GetCourses();
            return _mapper.Map<IEnumerable<CourseDto>>(coursesFromDAL);
        }

        public IEnumerable<SectionDto> GetSections()
        {
            var sectionsFromDAL = _DAL.GetCourses();
            return _mapper.Map<IEnumerable<SectionDto>>(sectionsFromDAL);
        }

        public StudentDto GetStudent(int id)
        {
            var studentsFromDAL = _DAL.GetStudent(id);
            return _mapper.Map<StudentDto>(studentsFromDAL);
        }

        public IEnumerable<StudentDto> GetStudents()
        {
            var studentsFromDAL = _DAL.GetStudents();
            return _mapper.Map<IEnumerable<StudentDto>>(studentsFromDAL);
        }

        public void UpdateStudent(int id, StudentForUpdateDto studentUpdateDto)
        {
            var studentFromDAL = _DAL.GetStudent(id);

            _mapper.Map(studentUpdateDto, studentFromDAL);

            _DAL.UpdateStudent(studentFromDAL);
            _DAL.Save();
        }
    }
}
