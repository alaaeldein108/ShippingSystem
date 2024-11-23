using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class deleteOrder_CODApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_COD_FOD_Apps");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "COD_FOD_Applications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_OrderNumber",
                table: "COD_FOD_Applications",
                column: "OrderNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_COD_FOD_Applications_Orders_OrderNumber",
                table: "COD_FOD_Applications",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COD_FOD_Applications_Orders_OrderNumber",
                table: "COD_FOD_Applications");

            migrationBuilder.DropIndex(
                name: "IX_COD_FOD_Applications_OrderNumber",
                table: "COD_FOD_Applications");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "COD_FOD_Applications");

            migrationBuilder.CreateTable(
                name: "Order_COD_FOD_Apps",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_COD_FOD_Apps", x => new { x.OrderNumber, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_Order_COD_FOD_Apps_COD_FOD_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "COD_FOD_Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_COD_FOD_Apps_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_COD_FOD_Apps_ApplicationId",
                table: "Order_COD_FOD_Apps",
                column: "ApplicationId");
        }
    }
}
