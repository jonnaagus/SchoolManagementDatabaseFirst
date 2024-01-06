using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementDatabaseFirst.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Student",
                newName: "ClassName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Principal",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "_FKStudentId",
                table: "Grades",
                newName: "_FKStudentID");

            migrationBuilder.RenameColumn(
                name: "_FKCourseId",
                table: "Grades",
                newName: "_FKCourseID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Teachers",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Teachers",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Staffs",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Principal",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Principal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Principal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_FKTeacherID",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FKStudentID",
                table: "GivesGrades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GradeDate",
                table: "GivesGrades",
                type: "datetime",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TeacherID",
                table: "Grades",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Teachers_TeacherID",
                table: "Grades",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Teachers_TeacherID",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_TeacherID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Principal");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Principal");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Principal");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "_FKTeacherID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "FKStudentID",
                table: "GivesGrades");

            migrationBuilder.DropColumn(
                name: "GradeDate",
                table: "GivesGrades");

            migrationBuilder.RenameColumn(
                name: "ClassName",
                table: "Student",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Principal",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "_FKStudentID",
                table: "Grades",
                newName: "_FKStudentId");

            migrationBuilder.RenameColumn(
                name: "_FKCourseID",
                table: "Grades",
                newName: "_FKCourseId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
