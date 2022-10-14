using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApp.Models
{
    public class StudentDetails
    {
        public Student Student { get; set; }
        public string CourseName { get; set; }
        public string SectionName { get; set; }
    }
}
