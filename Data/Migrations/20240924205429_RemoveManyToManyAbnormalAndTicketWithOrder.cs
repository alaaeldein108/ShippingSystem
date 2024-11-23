using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemoveManyToManyAbnormalAndTicketWithOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Tickets");

            migrationBuilder.DropTable(
                name: "OrderAbnormals");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "Abnormals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrderNumber",
                table: "Tickets",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_OrderNumber",
                table: "Abnormals",
                column: "OrderNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_Orders_OrderNumber",
                table: "Abnormals",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_OrderNumber",
                table: "Tickets",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abnormals_Orders_OrderNumber",
                table: "Abnormals");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_OrderNumber",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrderNumber",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Abnormals_OrderNumber",
                table: "Abnormals");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Abnormals");

            migrationBuilder.CreateTable(
                name: "Order_Tickets",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Tickets", x => new { x.OrderId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_Order_Tickets_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Tickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderAbnormals",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbnormalId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAbnormals", x => new { x.OrderId, x.AbnormalId });
                    table.ForeignKey(
                        name: "FK_OrderAbnormals_Abnormals_AbnormalId",
                        column: x => x.AbnormalId,
                        principalTable: "Abnormals",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAbnormals_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Tickets_TicketId",
                table: "Order_Tickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAbnormals_AbnormalId",
                table: "OrderAbnormals",
                column: "AbnormalId");
        }
    }
}
