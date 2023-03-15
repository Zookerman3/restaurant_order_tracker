using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class RestaurantsDBnameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAlcoholOrder_Restaurant_RestaurantId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMeatOrder_Restaurant_RestaurantId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantVegetableOrder_Restaurant_RestaurantId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "Restaurants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAlcoholOrder_Restaurants_RestaurantId",
                table: "RestaurantAlcoholOrder",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMeatOrder_Restaurants_RestaurantId",
                table: "RestaurantMeatOrder",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantVegetableOrder_Restaurants_RestaurantId",
                table: "RestaurantVegetableOrder",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAlcoholOrder_Restaurants_RestaurantId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMeatOrder_Restaurants_RestaurantId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantVegetableOrder_Restaurants_RestaurantId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAlcoholOrder_Restaurant_RestaurantId",
                table: "RestaurantAlcoholOrder",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMeatOrder_Restaurant_RestaurantId",
                table: "RestaurantMeatOrder",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantVegetableOrder_Restaurant_RestaurantId",
                table: "RestaurantVegetableOrder",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
