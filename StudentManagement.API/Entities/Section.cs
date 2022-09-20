using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Entities
{
    [Table("section")]
    public class Section
    {
        [Key]
        [Column("sectionId")]
        public int SectionId { get; set; }

        [Column("sectionName", TypeName = "char(1)")]
        public string SectionName { get; set; }
    }
}
