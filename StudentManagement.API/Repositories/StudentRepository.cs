using Microsoft.EntityFrameworkCore;
using StudentManagement.API.DbContexts;
using StudentManagement.API.Entities;
using StudentManagement.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement.API.Helpers;
using StudentManagement.API.Models;

namespace StudentManagement.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentMgmtContext _context;

        public StudentRepository(StudentMgmtContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddStudent(Student student)
        {
            if(student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Student.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Student.Remove(student);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Course.ToList<Course>();
        }

        public IEnumerable<Section> GetSections()
        {
            return _context.Section.ToList<Section>();
        }

        public IEnumerable<StudentCSModel> GetStudent(int Id)
        {
            var student = from s in _context.Student join c in _context.Course on s.CourseId equals c.CourseId join sec in _context.Section on s.SectionId equals sec.SectionId where s.Id == Id select new StudentCSModel { Student = s, CourseName = c.CourseName, SectionName = sec.SectionName };
            //using stored procedure instead of Linq
            //var student = _context.Student.FromSqlRaw<Student>("spGetStudentById {0}", Id).ToList().FirstOrDefault();

            return student;
        }

        public PagedList<StudentCSModel> GetStudents(StudentParameters studentParameters)
        {
            var students = from s in _context.Student join c in _context.Course on s.CourseId equals c.CourseId join sec in _context.Section on s.SectionId equals sec.SectionId select new StudentCSModel { Student = s, CourseName= c.CourseName,SectionName= sec.SectionName };

            if (!String.IsNullOrEmpty(studentParameters.SearchName))
            {
                students = students.Where(s => s.Student.FirstName.Contains(studentParameters.SearchName)
                || s.Student.LastName.Contains(studentParameters.SearchName));
            }

            switch (studentParameters.OrderBy)
            {
                
                case "Name_asc":
                    students = students.OrderBy(s => s.Student.FirstName).ThenBy(s => s.Student.LastName);
                    break;
                case "Name_desc":
                    students = students.OrderByDescending(s => s.Student.FirstName).ThenByDescending(s => s.Student.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.Student.DateOfAdmission);
                    break;
                case "Date_desc":
                    students = students.OrderByDescending(s => s.Student.DateOfAdmission);
                    break;
                default:
                    students = students.OrderByDescending(s => s.Student.Id);
                    break;

            }

            return PagedList<StudentCSModel>.ToPagedList(students,
                studentParameters.PageNumber,
                studentParameters.PageSize);

        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(int id, Student student)
        {
            if(_context.Student.Where(s => s.Id == id).AsNoTracking().FirstOrDefault() == null)
            {
                throw new NullReferenceException();
            }

            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChangesAsync();
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TodoItemExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            //Dto mapping
        }

        public Credentials LoginUser(string email, string pass)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                return null;
            }
            return _context.Credentials.FirstOrDefault(u => u.Username == email && u.Password == pass);
        }

    }
}
