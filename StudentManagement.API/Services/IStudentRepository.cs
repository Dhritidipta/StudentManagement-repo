using StudentManagement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int Id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        IEnumerable<Course> GetCourses();
        IEnumerable<Section> GetSections();
        bool Save();
    }
}
