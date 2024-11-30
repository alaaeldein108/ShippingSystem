using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemoveBranchRelationsInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BranchLevels_DeliveryBRId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BranchLevels_LastUpdateBRId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BranchLevels_PickupBRId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BranchLevels_SigningBRId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryBRId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LastUpdateBRId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PickupBRId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SigningBRId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryBRId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastUpdateBRId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickupBRId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SigningBRId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCourier",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdator",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickupCourier",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SigningCourier",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryCourier",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastUpdator",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickupCourier",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SigningCourier",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryBRId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastUpdateBRId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PickupBRId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SigningBRId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryBRId",
                table: "Orders",
                column: "DeliveryBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LastUpdateBRId",
                table: "Orders",
                column: "LastUpdateBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickupBRId",
                table: "Orders",
                column: "PickupBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SigningBRId",
                table: "Orders",
                column: "SigningBRId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BranchLevels_DeliveryBRId",
                table: "Orders",
                column: "DeliveryBRId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BranchLevels_LastUpdateBRId",
                table: "Orders",
                column: "LastUpdateBRId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BranchLevels_PickupBRId",
                table: "Orders",
                column: "PickupBRId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BranchLevels_SigningBRId",
                table: "Orders",
                column: "SigningBRId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
