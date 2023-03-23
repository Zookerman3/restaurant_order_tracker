using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vegetables",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Meats",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Alcohols",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Vegetables_UserId",
                table: "Vegetables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meats_UserId",
                table: "Meats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Alcohols_UserId",
                table: "Alcohols",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alcohols_AspNetUsers_UserId",
                table: "Alcohols",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meats_AspNetUsers_UserId",
                table: "Meats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vegetables_AspNetUsers_UserId",
                table: "Vegetables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alcohols_AspNetUsers_UserId",
                table: "Alcohols");

            migrationBuilder.DropForeignKey(
                name: "FK_Meats_AspNetUsers_UserId",
                table: "Meats");

            migrationBuilder.DropForeignKey(
                name: "FK_Vegetables_AspNetUsers_UserId",
                table: "Vegetables");

            migrationBuilder.DropIndex(
                name: "IX_Vegetables_UserId",
                table: "Vegetables");

            migrationBuilder.DropIndex(
                name: "IX_Meats_UserId",
                table: "Meats");

            migrationBuilder.DropIndex(
                name: "IX_Alcohols_UserId",
                table: "Alcohols");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Meats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Alcohols");
        }
    }
}
