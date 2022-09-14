using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Section { get; set; }
        public string Gender { get; set; }
        public int Fees { get; set; }
        public int Age { get; set; }
        public string CourseName { get; set; }
        public DateTime DateOfAdmission { get; set; }
    }

}
