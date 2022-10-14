using StudentManagement.API.Entities;
using StudentManagement.API.Helpers;
using StudentManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentService
    {
        (IEnumerable<StudentCSModel>, Metadata)  GetStudents(StudentParameters studentParameters);
        IEnumerable<StudentCSModel> GetStudent(int Id);
        StudentDto AddStudent(StudentForCreationDto studentCreationDto);
        void UpdateStudent(int id, StudentForUpdateDto studentUpdateDto);
        void DeleteStudent(int id);
        IEnumerable<CourseDto> GetCourses();
        IEnumerable<SectionDto> GetSections();
    }
}

