using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_S.Migrations
{
    /// <inheritdoc />
    public partial class AddIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            // name: "Id",  // Replace with your desired column name
            // table: "ClassSchedule",  // Replace with the name of your table
            // type: "nvarchar(max)",  // Replace with the desired data type
            // nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //name: "Id",
            //table: "ClassSchedule");
        }
    }
}
