using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTest.Migrations
{
    public partial class RenameSomeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Enrollment",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Enrollment",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "EnrollmentID",
                table: "Enrollment",
                newName: "EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Course",
                newName: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentId",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentId",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Enrollment",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Enrollment",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "EnrollmentId",
                table: "Enrollment",
                newName: "EnrollmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Course",
                newName: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
