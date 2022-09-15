using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApp.Models
{
    public class StudentUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Section { get; set; }
        public string Gender { get; set; }
        public int Fees { get; set; }
        public int Age { get; set; }
        public string CourseName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfAdmission { get; set; }
    }
}
