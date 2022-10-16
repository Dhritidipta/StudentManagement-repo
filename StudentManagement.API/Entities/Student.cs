using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Entities
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("firstName")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("lastName")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("sectionId")]
        public int? SectionId { get; set; }
        public Section Section { get; set; }

        [Required]
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [Column("fees")]
        public int Fees { get; set; }

        [Required]
        [Column("age")]
        public int Age { get; set; }
        [Column("courseId")]
        public int? CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        [Column("dateOfAdmission")]
        public DateTime DateOfAdmission { get; set; }

    }
}
