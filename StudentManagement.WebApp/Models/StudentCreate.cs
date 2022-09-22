using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement.WebApp.Validation;

namespace StudentManagement.WebApp.Models
{
    public class StudentCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Section")]
        [CheckSelctedValue(ErrorMessage = "Please select a valid category")]
        public string Section { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Fees { get; set; }

        [Required]
        [AgeShouldBeWithinRange(20, 100)]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        [CheckSelctedValue(ErrorMessage = "Please select a valid category")]
        public string Course { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Admission")]
        public DateTime DateOfAdmission { get; set; }
    }
}
