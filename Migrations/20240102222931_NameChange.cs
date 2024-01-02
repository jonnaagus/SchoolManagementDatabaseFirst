using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementDatabaseFirst.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FKStudentId",
                table: "Grades",
                newName: "_FKStudentId");

            migrationBuilder.RenameColumn(
                name: "FKCourseId",
                table: "Grades",
                newName: "_FKCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_FKStudentId",
                table: "Grades",
                newName: "FKStudentId");

            migrationBuilder.RenameColumn(
                name: "_FKCourseId",
                table: "Grades",
                newName: "FKCourseId");
        }
    }
}
