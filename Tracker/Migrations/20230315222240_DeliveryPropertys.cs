using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class DeliveryPropertys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "RestaurantVegetableOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "RestaurantMeatOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "RestaurantAlcoholOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryName",
                table: "Delivery",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantVegetableOrder_DeliveryId",
                table: "RestaurantVegetableOrder",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantMeatOrder_DeliveryId",
                table: "RestaurantMeatOrder",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantAlcoholOrder_DeliveryId",
                table: "RestaurantAlcoholOrder",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAlcoholOrder_Delivery_DeliveryId",
                table: "RestaurantAlcoholOrder",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMeatOrder_Delivery_DeliveryId",
                table: "RestaurantMeatOrder",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantVegetableOrder_Delivery_DeliveryId",
                table: "RestaurantVegetableOrder",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAlcoholOrder_Delivery_DeliveryId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMeatOrder_Delivery_DeliveryId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantVegetableOrder_Delivery_DeliveryId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantVegetableOrder_DeliveryId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantMeatOrder_DeliveryId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantAlcoholOrder_DeliveryId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryName",
                table: "Delivery");
        }
    }
}
