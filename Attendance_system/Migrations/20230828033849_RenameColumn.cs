using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_S.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "ClassSchedules",
                newName: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedules_CourseId",
                table: "ClassSchedules",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Courses_CourseId",
                table: "ClassSchedules",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Courses_CourseId",
                table: "ClassSchedules");

            migrationBuilder.DropIndex(
                name: "IX_ClassSchedules_CourseId",
                table: "ClassSchedules");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "ClassSchedules",
                newName: "CourseName");
        }
    }
}
