using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;
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
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudents()
        {
            var data = _studentService.GetStudents();
            return Ok(data);
        }

        [HttpGet("{id}", Name ="GetStudent")]
        public ActionResult GetStudent(int id)
        {
            var data = _studentService.GetStudent(id);
            if(data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public ActionResult<StudentDto> CreateStudent(StudentForCreationDto student)
        {
            var data = _studentService.AddStudent(student);
            return CreatedAtRoute("GetStudent", new { id = data.Id }, data);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentForUpdateDto student)
        {
            _studentService.UpdateStudent(id, student);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                _studentService.DeleteStudent(id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        [Route("~/api/courses")]
        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCourses()
        {
            var data = _studentService.GetCourses();
            return Ok(data);
        }

        [Route("~/api/sections")]
        [HttpGet]
        public ActionResult<IEnumerable<SectionDto>> GetSections()
        {
            var data = _studentService.GetSections();
            return Ok(data);
        }
    }
}
