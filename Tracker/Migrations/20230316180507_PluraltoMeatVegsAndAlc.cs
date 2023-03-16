using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class PluraltoMeatVegsAndAlc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAlcoholOrder_Alcohol_AlcoholId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMeatOrder_Meat_MeatId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantVegetableOrder_Vegetable_VegetableId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vegetable",
                table: "Vegetable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meat",
                table: "Meat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alcohol",
                table: "Alcohol");

            migrationBuilder.RenameTable(
                name: "Vegetable",
                newName: "Vegetables");

            migrationBuilder.RenameTable(
                name: "Meat",
                newName: "Meats");

            migrationBuilder.RenameTable(
                name: "Alcohol",
                newName: "Alcohols");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vegetables",
                table: "Vegetables",
                column: "VegetableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meats",
                table: "Meats",
                column: "MeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alcohols",
                table: "Alcohols",
                column: "AlcoholId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAlcoholOrder_Alcohols_AlcoholId",
                table: "RestaurantAlcoholOrder",
                column: "AlcoholId",
                principalTable: "Alcohols",
                principalColumn: "AlcoholId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMeatOrder_Meats_MeatId",
                table: "RestaurantMeatOrder",
                column: "MeatId",
                principalTable: "Meats",
                principalColumn: "MeatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantVegetableOrder_Vegetables_VegetableId",
                table: "RestaurantVegetableOrder",
                column: "VegetableId",
                principalTable: "Vegetables",
                principalColumn: "VegetableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAlcoholOrder_Alcohols_AlcoholId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMeatOrder_Meats_MeatId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantVegetableOrder_Vegetables_VegetableId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vegetables",
                table: "Vegetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meats",
                table: "Meats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alcohols",
                table: "Alcohols");

            migrationBuilder.RenameTable(
                name: "Vegetables",
                newName: "Vegetable");

            migrationBuilder.RenameTable(
                name: "Meats",
                newName: "Meat");

            migrationBuilder.RenameTable(
                name: "Alcohols",
                newName: "Alcohol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vegetable",
                table: "Vegetable",
                column: "VegetableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meat",
                table: "Meat",
                column: "MeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alcohol",
                table: "Alcohol",
                column: "AlcoholId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAlcoholOrder_Alcohol_AlcoholId",
                table: "RestaurantAlcoholOrder",
                column: "AlcoholId",
                principalTable: "Alcohol",
                principalColumn: "AlcoholId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMeatOrder_Meat_MeatId",
                table: "RestaurantMeatOrder",
                column: "MeatId",
                principalTable: "Meat",
                principalColumn: "MeatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantVegetableOrder_Vegetable_VegetableId",
                table: "RestaurantVegetableOrder",
                column: "VegetableId",
                principalTable: "Vegetable",
                principalColumn: "VegetableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
