using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class DeliveryIdToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "VegetableOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "MeatOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "AlcoholOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholOrders_Deliveries_DeliveryId",
                table: "AlcoholOrders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeatOrders_Deliveries_DeliveryId",
                table: "MeatOrders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableOrders_Deliveries_DeliveryId",
                table: "VegetableOrders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "VegetableOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "MeatOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "AlcoholOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
