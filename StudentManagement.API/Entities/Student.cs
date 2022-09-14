﻿using System;
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

        [Required]
        [Column("section", TypeName ="char(1)")]
        public char Section { get; set; }

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

        [Required]
        [Column("course")]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        [Column("dateOfAdmission")]
        public DateTime DateOfAdmission { get; set; }

    }
}