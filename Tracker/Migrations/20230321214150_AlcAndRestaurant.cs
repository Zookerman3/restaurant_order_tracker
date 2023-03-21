using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class AlcAndRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlcAndRestaurant",
                table: "Alcohols");

            migrationBuilder.AddColumn<string>(
                name: "AlcAndRestaurant",
                table: "AlcoholOrders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlcAndRestaurant",
                table: "AlcoholOrders");

            migrationBuilder.AddColumn<string>(
                name: "AlcAndRestaurant",
                table: "Alcohols",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
