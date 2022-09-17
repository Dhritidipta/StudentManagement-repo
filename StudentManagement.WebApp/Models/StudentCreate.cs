using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApp.Models
{
    public class StudentCreate
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public char Section { get; set; }
        public string Gender { get; set; }
        public int Fees { get; set; }
        public int Age { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Admission")]
        public DateTime DateOfAdmission { get; set; }
    }
}
