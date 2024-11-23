using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemoveClientQuotationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Quotations_QuotationId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Client_Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Clients_QuotationId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ClientCode",
                table: "Quotations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClientQuotation",
                columns: table => new
                {
                    ClientsClientCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuotationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientQuotation", x => new { x.ClientsClientCode, x.QuotationsId });
                    table.ForeignKey(
                        name: "FK_ClientQuotation_Clients_ClientsClientCode",
                        column: x => x.ClientsClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientQuotation_Quotations_QuotationsId",
                        column: x => x.QuotationsId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ClientCode",
                table: "Quotations",
                column: "ClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClientQuotation_QuotationsId",
                table: "ClientQuotation",
                column: "QuotationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Clients_ClientCode",
                table: "Quotations",
                column: "ClientCode",
                principalTable: "Clients",
                principalColumn: "ClientCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Clients_ClientCode",
                table: "Quotations");

            migrationBuilder.DropTable(
                name: "ClientQuotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_ClientCode",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ClientCode",
                table: "Quotations");

            migrationBuilder.AddColumn<int>(
                name: "QuotationId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client_Quotations",
                columns: table => new
                {
                    ClientCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuotationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Quotations", x => new { x.ClientCode, x.QuotationId });
                    table.ForeignKey(
                        name: "FK_Client_Quotations_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Quotations_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_QuotationId",
                table: "Clients",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Quotations_QuotationId",
                table: "Client_Quotations",
                column: "QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Quotations_QuotationId",
                table: "Clients",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id");
        }
    }
}
