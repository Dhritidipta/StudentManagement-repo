using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SectionId { get; set; }
        public string Gender { get; set; }
        public int Fees { get; set; }
        public int Age { get; set; }
        public int CourseId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfAdmission { get; set; }
    }
}
