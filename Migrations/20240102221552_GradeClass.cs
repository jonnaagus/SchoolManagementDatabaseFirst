using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementDatabaseFirst.Migrations
{
    public partial class GradeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FKCourseID",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FKStudentID",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseID",
                table: "Grades",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                table: "Grades",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_CourseID",
                table: "Grades",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Student_StudentID",
                table: "Grades",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_CourseID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Student_StudentID",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_CourseID",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "FKCourseId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "FKStudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Grades");
        }
    }
}
