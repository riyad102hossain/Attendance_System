using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_S.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyToClassSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClassSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedules",
                table: "ClassSchedules",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedules",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClassSchedules");
        }
    }
}
