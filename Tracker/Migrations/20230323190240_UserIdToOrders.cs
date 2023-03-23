using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class UserIdToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "VegetableOrders",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MeatOrders",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AlcoholOrders",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_VegetableOrders_UserId",
                table: "VegetableOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeatOrders_UserId",
                table: "MeatOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholOrders_UserId",
                table: "AlcoholOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholOrders_AspNetUsers_UserId",
                table: "AlcoholOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeatOrders_AspNetUsers_UserId",
                table: "MeatOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableOrders_AspNetUsers_UserId",
                table: "VegetableOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlcoholOrders_AspNetUsers_UserId",
                table: "AlcoholOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MeatOrders_AspNetUsers_UserId",
                table: "MeatOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableOrders_AspNetUsers_UserId",
                table: "VegetableOrders");

            migrationBuilder.DropIndex(
                name: "IX_VegetableOrders_UserId",
                table: "VegetableOrders");

            migrationBuilder.DropIndex(
                name: "IX_MeatOrders_UserId",
                table: "MeatOrders");

            migrationBuilder.DropIndex(
                name: "IX_AlcoholOrders_UserId",
                table: "AlcoholOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "VegetableOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MeatOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AlcoholOrders");
        }
    }
}
