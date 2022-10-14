using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.API.Entities;
using StudentManagement.API.Helpers;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult<IEnumerable<StudentDto>> GetStudents([FromQuery] StudentParameters studentParameters)
        {
            (IEnumerable<StudentCSModel>,Metadata) data;
            IEnumerable<StudentCSModel> students; 
            try
            {
                data = _studentService.GetStudents(studentParameters);

            }
            catch (NullReferenceException)
            {
                return StatusCode(500);
            }
            
            students = data.Item1;
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(data.Item2));


            return Ok(students);
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
        public ActionResult<StudentDto> CreateStudent([ModelBinder(BinderType = typeof(NotEmptyListOfResponseModels))]StudentForCreationDto student)
        {
            StudentDto data;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            data = _studentService.AddStudent(student);
            return CreatedAtRoute("GetStudent", new { id = data.Id }, data);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentForUpdateDto student)
        {
            try
            {
                _studentService.UpdateStudent(id, student);

            }
            catch (NullReferenceException)
            {

                return StatusCode(404);
            }

            return Ok("Successfully updated!");

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
            IEnumerable<CourseDto> data;
            try
            {
                data = _studentService.GetCourses();
            }
            catch (NullReferenceException)
            {

                return StatusCode(500);
            }
            return Ok(data);
        }

        [Route("~/api/sections")]
        [HttpGet]
        public ActionResult<IEnumerable<SectionDto>> GetSections()
        {
            IEnumerable<SectionDto> data;
            try
            {
                data = _studentService.GetSections();
            }
            catch (NullReferenceException)
            {

                return StatusCode(500);
            }
            return Ok(data);
        }
    }
}
