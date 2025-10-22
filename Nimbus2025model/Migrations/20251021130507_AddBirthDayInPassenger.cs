using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus2025model.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthDayInPassenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                table: "Persons",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "Persons");
        }
    }
}
