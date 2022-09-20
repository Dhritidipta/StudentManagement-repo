using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.API.Migrations
{
    public partial class spGetStudentById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetStudentById
                                    @id int
                                    as 
                                    Begin
                                        Select * from student
                                    where id = @id
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetStudentById";
            migrationBuilder.Sql(procedure);
        }
    }
}
