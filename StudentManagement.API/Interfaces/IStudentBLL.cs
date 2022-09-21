using StudentManagement.API.Entities;
using StudentManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentBLL
    {
        IEnumerable<StudentDto> GetStudents();
        StudentDto GetStudent(int Id);
        StudentDto AddStudent(StudentForCreationDto studentCreationDto);
        void UpdateStudent(int id, StudentForUpdateDto studentUpdateDto);
        void DeleteStudent(int id);
        IEnumerable<CourseDto> GetCourses();
        IEnumerable<SectionDto> GetSections();
    }
}

