using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Models
{
    public class StudentForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Section { get; set; }
        public string Gender { get; set; }
        public int Fees { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public DateTime DateOfAdmission { get; set; }
    }
}
