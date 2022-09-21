﻿using StudentManagement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentDAL
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