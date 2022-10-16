using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.API.Entities;
using StudentManagement.API.Helpers;
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
            var student = studentFromRepo.FirstOrDefault().Student;

            if (studentFromRepo == null || student == null)
            {
                throw new NullReferenceException("Not found");
            }


            _studentRepo.DeleteStudent(student);
            _studentRepo.Save();
        }

        public IEnumerable<CourseDto> GetCourses()
        {
            var coursesFromDAL = _studentRepo.GetCourses();
            if(coursesFromDAL == null)
            {
                throw new NullReferenceException();
            }
            return _mapper.Map<IEnumerable<CourseDto>>(coursesFromDAL);
        }

        public IEnumerable<SectionDto> GetSections()
        {
            var sectionsFromDAL = _studentRepo.GetSections();
            if(sectionsFromDAL == null)
            {
                throw new NullReferenceException();
            }
            return _mapper.Map<IEnumerable<SectionDto>>(sectionsFromDAL);
        }

        public IEnumerable<StudentCSModel> GetStudent(int id)
        {
            var studentsFromDAL = _studentRepo.GetStudent(id);
            if(studentsFromDAL.Count() == 0)
            {
                return null;
            }
            return studentsFromDAL;
        }

        public (IEnumerable<StudentCSModel>, Metadata) GetStudents(StudentParameters studentParameters)
        {
            var studentsFromDAL = _studentRepo.GetStudents(studentParameters);
            Metadata metadata = new Metadata()
            {
                TotalCount = studentsFromDAL.TotalCount,
                PageSize = studentsFromDAL.PageSize,
                CurrentPage = studentsFromDAL.CurrentPage,
                TotalPages = studentsFromDAL.TotalPages,
                HasNext = studentsFromDAL.HasNext,
                HasPrevious = studentsFromDAL.HasPrevious
            };

            if (studentsFromDAL == null || metadata == null)
            {
                throw new ArgumentNullException();
            }
            return (studentsFromDAL, metadata);
        }

        public CredentialsDto LoginUser(string username, string password)
        {
            var userFromDAL = _studentRepo.LoginUser(username, password);
            return _mapper.Map<CredentialsDto>(userFromDAL);
        }

        public void UpdateStudent(int id, StudentForUpdateDto studentUpdateDto)
        {
            //var studentFromRepo = _studentRepo.GetStudent(id).SingleOrDefault();
            var studentEntity = new Student
            {
                Id = id,
                FirstName = studentUpdateDto.FirstName,
                LastName = studentUpdateDto.LastName,
                SectionId = studentUpdateDto.SectionId,
                CourseId = studentUpdateDto.CourseId,
                Gender = studentUpdateDto.Gender,
                Fees = studentUpdateDto.Fees,
                Age = studentUpdateDto.Age,
                DateOfAdmission = studentUpdateDto.DateOfAdmission
            };

            //_mapper.Map(studentUpdateDto, studentEntity);
            //var studentEntity = _mapper.Map<Student>(studentFromRepo);
            try
            {
                _studentRepo.UpdateStudent(id, studentEntity);

            }
            catch (NullReferenceException e)
            {

                throw e;
            }
            //_studentRepo.UpdateStudent(studentFromRepo);
            //_studentRepo.Save();
            //var studentFromRepoU = _studentRepo.GetStudent(id).SingleOrDefault();
        }
    }
}
