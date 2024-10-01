using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_S.Migrations
{
    /// <inheritdoc />
    public partial class CreateClassScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassSchedules",
                columns: table => new
                {
                    CourseName = table.Column<int>(type: "int", nullable: false),
                    Day1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSchedules");
        }
    }
}
