using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTest.Migrations
{
    public partial class AddAgeFieldToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Student",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Student");
        }
    }
}
