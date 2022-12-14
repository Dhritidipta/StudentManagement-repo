using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.API.Migrations
{
    public partial class ModifyCourseSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_section_SectionId",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_student_SectionId",
                table: "student");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "student");

            migrationBuilder.AddColumn<string>(
                name: "course",
                table: "student",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "section",
                table: "student",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "course",
                table: "student");

            migrationBuilder.DropColumn(
                name: "section",
                table: "student");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_CourseId",
                table: "student",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_student_SectionId",
                table: "student",
                column: "SectionId");

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
