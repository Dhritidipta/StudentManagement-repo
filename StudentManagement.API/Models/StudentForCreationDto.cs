using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Models
{
    public class StudentForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SectionId { get; set; }
        public string Gender { get; set; }
        public int Fees { get; set; }
        public int Age { get; set; }
        public int CourseId { get; set; }
        public DateTime DateOfAdmission { get; set; }
    }
}
