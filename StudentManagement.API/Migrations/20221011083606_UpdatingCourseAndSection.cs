using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.API.Migrations
{
    public partial class UpdatingCourseAndSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_course_CourseId",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_section_SectionId",
                table: "student");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "student",
                newName: "sectionId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "student",
                newName: "courseId");

            migrationBuilder.RenameIndex(
                name: "IX_student_SectionId",
                table: "student",
                newName: "IX_student_sectionId");

            migrationBuilder.RenameIndex(
                name: "IX_student_CourseId",
                table: "student",
                newName: "IX_student_courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_student_course_courseId",
                table: "student",
                column: "courseId",
                principalTable: "course",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_student_section_sectionId",
                table: "student",
                column: "sectionId",
                principalTable: "section",
                principalColumn: "sectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_course_courseId",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_section_sectionId",
                table: "student");

            migrationBuilder.RenameColumn(
                name: "sectionId",
                table: "student",
                newName: "SectionId");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "student",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_student_sectionId",
                table: "student",
                newName: "IX_student_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_student_courseId",
                table: "student",
                newName: "IX_student_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_student_course_CourseId",
                table: "student",
                column: "CourseId",
                principalTable: "course",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_student_section_SectionId",
                table: "student",
                column: "SectionId",
                principalTable: "section",
                principalColumn: "sectionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
