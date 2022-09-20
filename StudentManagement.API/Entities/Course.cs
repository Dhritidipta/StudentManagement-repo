using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Entities
{
    [Table("course")]
    public class Course
    {
        [Key]
        [Column("courseId")]
        public int CourseId { get; set; }
        [Column("courseName")]
        public string CourseName { get; set; }
    }
}
