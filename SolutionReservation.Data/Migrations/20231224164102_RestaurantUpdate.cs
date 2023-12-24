using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionReservation.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Restaurants");
        }
    }
}
