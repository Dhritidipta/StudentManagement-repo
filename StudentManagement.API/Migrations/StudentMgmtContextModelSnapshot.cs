﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.API.DbContexts;

namespace StudentManagement.API.Migrations
{
    [DbContext(typeof(StudentMgmtContext))]
    partial class StudentMgmtContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentManagement.API.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("courseId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .HasColumnName("courseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("course");
                });

            modelBuilder.Entity("StudentManagement.API.Entities.Credentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("StudentManagement.API.Entities.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sectionId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SectionName")
                        .HasColumnName("sectionName")
                        .HasColumnType("char(1)");

                    b.HasKey("SectionId");

                    b.ToTable("section");
                });

            modelBuilder.Entity("StudentManagement.API.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnName("age")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnName("courseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAdmission")
                        .HasColumnName("dateOfAdmission")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fees")
                        .HasColumnName("fees")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("firstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnName("gender")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("lastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("SectionId")
                        .HasColumnName("sectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("SectionId");

                    b.ToTable("student");
                });

            modelBuilder.Entity("StudentManagement.API.Entities.Student", b =>
                {
                    b.HasOne("StudentManagement.API.Entities.Course", "Course")
                        .WithMany("Student")
                        .HasForeignKey("CourseId");

                    b.HasOne("StudentManagement.API.Entities.Section", "Section")
                        .WithMany("Student")
                        .HasForeignKey("SectionId");
                });
#pragma warning restore 612, 618
        }
    }
}
