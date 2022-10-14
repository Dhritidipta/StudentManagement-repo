using StudentManagement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Models
{
    public class StudentCSModel
    {
        public  Student Student { get; set; }
        public string CourseName { get; set; }
        public string SectionName { get; set; }
    }
}
