using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itinerary_Designer.Migrations
{
    /// <inheritdoc />
    public partial class secondary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostPerItineraryEUR",
                table: "Itineraries",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCostPerItineraryEUR",
                table: "Itineraries");
        }
    }
}
