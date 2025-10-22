using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus2025model.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationAirportsCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirportCity",
                columns: table => new
                {
                    AirportsId = table.Column<int>(type: "int", nullable: false),
                    CitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCity", x => new { x.AirportsId, x.CitiesId });
                    table.ForeignKey(
                        name: "FK_AirportCity_Airports_AirportsId",
                        column: x => x.AirportsId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirportCity_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportCity_CitiesId",
                table: "AirportCity",
                column: "CitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportCity");
        }
    }
}
