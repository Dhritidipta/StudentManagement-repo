using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApp.Models
{
    public class StudentUpdate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        
        [Required]
        public string LastName { get; set; }
        [Required]
        public char Section { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Fees { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public String CourseName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Admission")]
        public DateTime DateOfAdmission { get; set; }
    }
}
