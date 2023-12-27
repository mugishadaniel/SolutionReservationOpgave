using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionReservation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableProper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_TableEF_Restaurants_RestaurantEFId",
                table: "TableEF");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableEF",
                table: "TableEF");

            migrationBuilder.RenameTable(
                name: "TableEF",
                newName: "Tables");

            migrationBuilder.RenameIndex(
                name: "IX_TableEF_RestaurantEFId",
                table: "Tables",
                newName: "IX_Tables_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "TableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantEFId",
                table: "Tables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantEFId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "TableEF");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_RestaurantEFId",
                table: "TableEF",
                newName: "IX_TableEF_RestaurantEFId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableEF",
                table: "TableEF",
                column: "TableID");

            migrationBuilder.AddForeignKey(
                name: "FK_TableEF_Restaurants_RestaurantEFId",
                table: "TableEF",
                column: "RestaurantEFId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }
    }
}
