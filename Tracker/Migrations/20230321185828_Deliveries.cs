using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class Deliveries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlcoholOrders_Delivery_DeliveryId",
                table: "AlcoholOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MeatOrders_Delivery_DeliveryId",
                table: "MeatOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableOrders_Delivery_DeliveryId",
                table: "VegetableOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Delivery",
                table: "Delivery");

            migrationBuilder.RenameTable(
                name: "Delivery",
                newName: "Deliveries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholOrders_Deliveries_DeliveryId",
                table: "AlcoholOrders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeatOrders_Deliveries_DeliveryId",
                table: "MeatOrders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableOrders_Deliveries_DeliveryId",
                table: "VegetableOrders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlcoholOrders_Deliveries_DeliveryId",
                table: "AlcoholOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MeatOrders_Deliveries_DeliveryId",
                table: "MeatOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableOrders_Deliveries_DeliveryId",
                table: "VegetableOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries");

            migrationBuilder.RenameTable(
                name: "Deliveries",
                newName: "Delivery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delivery",
                table: "Delivery",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholOrders_Delivery_DeliveryId",
                table: "AlcoholOrders",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeatOrders_Delivery_DeliveryId",
                table: "MeatOrders",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableOrders_Delivery_DeliveryId",
                table: "VegetableOrders",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");
        }
    }
}
