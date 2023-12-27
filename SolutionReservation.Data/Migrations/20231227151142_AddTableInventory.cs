using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionReservation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "TableEF",
                columns: table => new
                {
                    TableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    RestaurantEFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableEF", x => x.TableID);
                    table.ForeignKey(
                        name: "FK_TableEF_Restaurants_RestaurantEFId",
                        column: x => x.RestaurantEFId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableEF_RestaurantEFId",
                table: "TableEF",
                column: "RestaurantEFId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableEF");

            migrationBuilder.AddColumn<int>(
                name: "TableInventoryRestaurantID",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TableInventoryEF",
                columns: table => new
                {
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EightSeaterCount = table.Column<int>(type: "int", nullable: false),
                    FourSeaterCount = table.Column<int>(type: "int", nullable: false),
                    SixSeaterCount = table.Column<int>(type: "int", nullable: false),
                    TwelveSeaterCount = table.Column<int>(type: "int", nullable: false),
                    TwoSeaterCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableInventoryEF", x => x.RestaurantID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_TableInventoryRestaurantID",
                table: "Restaurants",
                column: "TableInventoryRestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_TableInventoryEF_TableInventoryRestaurantID",
                table: "Restaurants",
                column: "TableInventoryRestaurantID",
                principalTable: "TableInventoryEF",
                principalColumn: "RestaurantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
