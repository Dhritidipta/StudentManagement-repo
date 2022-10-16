using StudentManagement.API.Entities;
using StudentManagement.API.Helpers;
using StudentManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentRepository
    {
        PagedList<StudentCSModel> GetStudents(StudentParameters studentParameters);
        IEnumerable<StudentCSModel> GetStudent(int Id);
        void AddStudent(Student student);
        void UpdateStudent(int id, Student student);
        void DeleteStudent(Student student);
        IEnumerable<Course> GetCourses();
        IEnumerable<Section> GetSections();
        bool Save();
        Credentials LoginUser(string username, string password); 
    }
}
