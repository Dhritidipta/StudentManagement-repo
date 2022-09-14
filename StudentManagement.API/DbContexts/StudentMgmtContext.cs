using Microsoft.EntityFrameworkCore;
using StudentManagement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.DbContexts
{
    public class StudentMgmtContext : DbContext
    {
        public StudentMgmtContext(DbContextOptions<StudentMgmtContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}