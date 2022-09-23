using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.API.Entities;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;

namespace StudentManagement.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepo = studentRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public StudentDto AddStudent(StudentForCreationDto studentCreationDto)
        {
            var studentEntity = _mapper.Map<Student>(studentCreationDto);
            _studentRepo.AddStudent(studentEntity);
            _studentRepo.Save();

            return _mapper.Map<StudentDto>(studentEntity);
        }

        public void DeleteStudent(int id)
        {
            var studentFromRepo = _studentRepo.GetStudent(id);

            if (studentFromRepo == null)
            {
                throw new NullReferenceException("Not found");
            }

            _studentRepo.DeleteStudent(studentFromRepo);
            _studentRepo.Save();
        }

        public IEnumerable<CourseDto> GetCourses()
        {
            var coursesFromDAL = _studentRepo.GetCourses();
            return _mapper.Map<IEnumerable<CourseDto>>(coursesFromDAL);
        }

        public IEnumerable<SectionDto> GetSections()
        {
            var sectionsFromDAL = _studentRepo.GetSections();
            return _mapper.Map<IEnumerable<SectionDto>>(sectionsFromDAL);
        }

        public StudentDto GetStudent(int id)
        {
            var studentsFromDAL = _studentRepo.GetStudent(id);
            return _mapper.Map<StudentDto>(studentsFromDAL);
        }

        public IEnumerable<StudentDto> GetStudents()
        {
            var studentsFromDAL = _studentRepo.GetStudents();
            return _mapper.Map<IEnumerable<StudentDto>>(studentsFromDAL);
        }

        public void UpdateStudent(int id, StudentForUpdateDto studentUpdateDto)
        {
            var studentFromRepo = _studentRepo.GetStudent(id);

            _mapper.Map(studentUpdateDto, studentFromRepo);

            _studentRepo.UpdateStudent(studentFromRepo);
            _studentRepo.Save();
        }
    }
}
