using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Models;
using StudentManagement.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _stuentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _stuentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> Getstudents()
        {
            var studentsFromRepo = _stuentRepository.GetStudents();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(studentsFromRepo));
        }

        [HttpGet("{id}", Name ="GetStudent")]
        public ActionResult GetStudent(int id)
        {
            var studentsFromRepo = _stuentRepository.GetStudent(id);

            if(studentsFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentDto>(studentsFromRepo));
        }

        [HttpPost]
        public ActionResult<StudentDto> CreateStudent(StudentForCreationDto student)
        {
            var studentEntity = _mapper.Map<Entities.Student>(student);
            _stuentRepository.AddStudent(studentEntity);
            _stuentRepository.Save();

            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return CreatedAtRoute("GetStudent", new { id = studentToReturn.Id }, studentToReturn);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentForUpdateDto student)
        {
            var studentFromRepo = _stuentRepository.GetStudent(id);

            _mapper.Map(student, studentFromRepo);

            _stuentRepository.UpdateStudent(studentFromRepo);
            _stuentRepository.Save();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentFromRepo = _stuentRepository.GetStudent(id);

            if(studentFromRepo == null)
            {
                return NotFound();
            }

            _stuentRepository.DeleteStudent(studentFromRepo);
            _stuentRepository.Save();

            return NoContent();
        }

        [HttpGet("courses")]
        public ActionResult<IEnumerable<CourseDto>> GetCourses()
        {
            var coursesFromRepo = _stuentRepository.GetCourses();
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(coursesFromRepo));
        }
        
        
        [HttpGet("sections")]
        public ActionResult<IEnumerable<SectionDto>> GetSections()
        {
            var sectionsFromRepo = _stuentRepository.GetSections();
            return Ok(_mapper.Map<IEnumerable<SectionDto>>(sectionsFromRepo));
        }
    }
}
