using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Migrations
{
    public partial class PluralToJoinEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAlcoholOrder_Alcohols_AlcoholId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAlcoholOrder_Delivery_DeliveryId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAlcoholOrder_Restaurants_RestaurantId",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMeatOrder_Delivery_DeliveryId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMeatOrder_Meats_MeatId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMeatOrder_Restaurants_RestaurantId",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantVegetableOrder_Delivery_DeliveryId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantVegetableOrder_Restaurants_RestaurantId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantVegetableOrder_Vegetables_VegetableId",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantVegetableOrder",
                table: "RestaurantVegetableOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantMeatOrder",
                table: "RestaurantMeatOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantAlcoholOrder",
                table: "RestaurantAlcoholOrder");

            migrationBuilder.RenameTable(
                name: "RestaurantVegetableOrder",
                newName: "VegetableOrders");

            migrationBuilder.RenameTable(
                name: "RestaurantMeatOrder",
                newName: "MeatOrders");

            migrationBuilder.RenameTable(
                name: "RestaurantAlcoholOrder",
                newName: "AlcoholOrders");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantVegetableOrder_VegetableId",
                table: "VegetableOrders",
                newName: "IX_VegetableOrders_VegetableId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantVegetableOrder_RestaurantId",
                table: "VegetableOrders",
                newName: "IX_VegetableOrders_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantVegetableOrder_DeliveryId",
                table: "VegetableOrders",
                newName: "IX_VegetableOrders_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantMeatOrder_RestaurantId",
                table: "MeatOrders",
                newName: "IX_MeatOrders_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantMeatOrder_MeatId",
                table: "MeatOrders",
                newName: "IX_MeatOrders_MeatId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantMeatOrder_DeliveryId",
                table: "MeatOrders",
                newName: "IX_MeatOrders_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantAlcoholOrder_RestaurantId",
                table: "AlcoholOrders",
                newName: "IX_AlcoholOrders_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantAlcoholOrder_DeliveryId",
                table: "AlcoholOrders",
                newName: "IX_AlcoholOrders_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantAlcoholOrder_AlcoholId",
                table: "AlcoholOrders",
                newName: "IX_AlcoholOrders_AlcoholId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VegetableOrders",
                table: "VegetableOrders",
                column: "VegetableOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeatOrders",
                table: "MeatOrders",
                column: "MeatOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlcoholOrders",
                table: "AlcoholOrders",
                column: "AlcoholOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholOrders_Alcohols_AlcoholId",
                table: "AlcoholOrders",
                column: "AlcoholId",
                principalTable: "Alcohols",
                principalColumn: "AlcoholId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholOrders_Delivery_DeliveryId",
                table: "AlcoholOrders",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlcoholOrders_Restaurants_RestaurantId",
                table: "AlcoholOrders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeatOrders_Delivery_DeliveryId",
                table: "MeatOrders",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeatOrders_Meats_MeatId",
                table: "MeatOrders",
                column: "MeatId",
                principalTable: "Meats",
                principalColumn: "MeatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeatOrders_Restaurants_RestaurantId",
                table: "MeatOrders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableOrders_Delivery_DeliveryId",
                table: "VegetableOrders",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableOrders_Restaurants_RestaurantId",
                table: "VegetableOrders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VegetableOrders_Vegetables_VegetableId",
                table: "VegetableOrders",
                column: "VegetableId",
                principalTable: "Vegetables",
                principalColumn: "VegetableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlcoholOrders_Alcohols_AlcoholId",
                table: "AlcoholOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AlcoholOrders_Delivery_DeliveryId",
                table: "AlcoholOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AlcoholOrders_Restaurants_RestaurantId",
                table: "AlcoholOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MeatOrders_Delivery_DeliveryId",
                table: "MeatOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MeatOrders_Meats_MeatId",
                table: "MeatOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MeatOrders_Restaurants_RestaurantId",
                table: "MeatOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableOrders_Delivery_DeliveryId",
                table: "VegetableOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableOrders_Restaurants_RestaurantId",
                table: "VegetableOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_VegetableOrders_Vegetables_VegetableId",
                table: "VegetableOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VegetableOrders",
                table: "VegetableOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeatOrders",
                table: "MeatOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlcoholOrders",
                table: "AlcoholOrders");

            migrationBuilder.RenameTable(
                name: "VegetableOrders",
                newName: "RestaurantVegetableOrder");

            migrationBuilder.RenameTable(
                name: "MeatOrders",
                newName: "RestaurantMeatOrder");

            migrationBuilder.RenameTable(
                name: "AlcoholOrders",
                newName: "RestaurantAlcoholOrder");

            migrationBuilder.RenameIndex(
                name: "IX_VegetableOrders_VegetableId",
                table: "RestaurantVegetableOrder",
                newName: "IX_RestaurantVegetableOrder_VegetableId");

            migrationBuilder.RenameIndex(
                name: "IX_VegetableOrders_RestaurantId",
                table: "RestaurantVegetableOrder",
                newName: "IX_RestaurantVegetableOrder_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_VegetableOrders_DeliveryId",
                table: "RestaurantVegetableOrder",
                newName: "IX_RestaurantVegetableOrder_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_MeatOrders_RestaurantId",
                table: "RestaurantMeatOrder",
                newName: "IX_RestaurantMeatOrder_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_MeatOrders_MeatId",
                table: "RestaurantMeatOrder",
                newName: "IX_RestaurantMeatOrder_MeatId");

            migrationBuilder.RenameIndex(
                name: "IX_MeatOrders_DeliveryId",
                table: "RestaurantMeatOrder",
                newName: "IX_RestaurantMeatOrder_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_AlcoholOrders_RestaurantId",
                table: "RestaurantAlcoholOrder",
                newName: "IX_RestaurantAlcoholOrder_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_AlcoholOrders_DeliveryId",
                table: "RestaurantAlcoholOrder",
                newName: "IX_RestaurantAlcoholOrder_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_AlcoholOrders_AlcoholId",
                table: "RestaurantAlcoholOrder",
                newName: "IX_RestaurantAlcoholOrder_AlcoholId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantVegetableOrder",
                table: "RestaurantVegetableOrder",
                column: "VegetableOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantMeatOrder",
                table: "RestaurantMeatOrder",
                column: "MeatOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantAlcoholOrder",
                table: "RestaurantAlcoholOrder",
                column: "AlcoholOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAlcoholOrder_Alcohols_AlcoholId",
                table: "RestaurantAlcoholOrder",
                column: "AlcoholId",
                principalTable: "Alcohols",
                principalColumn: "AlcoholId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAlcoholOrder_Delivery_DeliveryId",
                table: "RestaurantAlcoholOrder",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAlcoholOrder_Restaurants_RestaurantId",
                table: "RestaurantAlcoholOrder",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMeatOrder_Delivery_DeliveryId",
                table: "RestaurantMeatOrder",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMeatOrder_Meats_MeatId",
                table: "RestaurantMeatOrder",
                column: "MeatId",
                principalTable: "Meats",
                principalColumn: "MeatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMeatOrder_Restaurants_RestaurantId",
                table: "RestaurantMeatOrder",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantVegetableOrder_Delivery_DeliveryId",
                table: "RestaurantVegetableOrder",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantVegetableOrder_Restaurants_RestaurantId",
                table: "RestaurantVegetableOrder",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantVegetableOrder_Vegetables_VegetableId",
                table: "RestaurantVegetableOrder",
                column: "VegetableId",
                principalTable: "Vegetables",
                principalColumn: "VegetableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
