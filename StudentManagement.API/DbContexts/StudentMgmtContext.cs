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
        public DbSet<Course> Course { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
    }
}