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
        private readonly IStudentBLL _BLL;

        public StudentsController(IStudentBLL bLL)
        {
            _BLL = bLL ?? throw new ArgumentNullException(nameof(bLL));
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudents()
        {
            var data = _BLL.GetStudents();
            return Ok(data);
        }

        [HttpGet("{id}", Name ="GetStudent")]
        public ActionResult GetStudent(int id)
        {
            var data = _BLL.GetStudent(id);
            if(data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public ActionResult<StudentDto> CreateStudent(StudentForCreationDto student)
        {
            var data = _BLL.AddStudent(student);
            return CreatedAtRoute("GetStudent", new { id = data.Id }, data);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentForUpdateDto student)
        {
            _BLL.UpdateStudent(id, student);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                _BLL.DeleteStudent(id);
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
            var data = _BLL.GetCourses();
            return Ok(data);
        }

        [Route("~/api/sections")]
        [HttpGet]
        public ActionResult<IEnumerable<SectionDto>> GetSections()
        {
            var data = _BLL.GetSections();
            return Ok(data);
        }
    }
}
