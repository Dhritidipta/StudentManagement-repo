using StudentManagement.API.DbContexts;
using StudentManagement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Services
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

        public Student GetStudent(int Id)
        {
            return _context.Student.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Student.ToList<Student>();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student student)
        {
            //Dto mapping
        }
    }
}
