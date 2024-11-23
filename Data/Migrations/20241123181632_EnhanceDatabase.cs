using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class EnhanceDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abnormals_Users_RegisterId",
                table: "Abnormals");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_Users_CreatorId",
                table: "BranchLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_Users_ModifiedId",
                table: "BranchLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_Users_PrincipalId",
                table: "BranchLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Cash_FODCollections_Users_CollectorId",
                table: "Cash_FODCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatorId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_ModifiedId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_SalesPersonId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_COD_Collections_Users_CollectorId",
                table: "COD_Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_COD_FOD_Applications_BranchLevels_ApplyingBranchId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_COD_FOD_Applications_BranchLevels_RecievingBranchId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_COD_FOD_Applications_Users_AuditorId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_COD_FOD_Applications_Users_RegisterId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreatorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_ModifiedId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Scans_BranchLevels_PreviousBranchId",
                table: "Order_Scans");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Scans_Users_DeliveryCourierId",
                table: "Order_Scans");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Scans_Users_PickupCourierId",
                table: "Order_Scans");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Scans_Users_ScannerId",
                table: "Order_Scans");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_DeliveryCourierId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_PickupCourierId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_CreatorId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_ModifiedId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Users_CreatorId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Users_ModifiedId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Clients_ClientCode",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_CreatorId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_ModifiedId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Return_ChangeAdd_Apps_BranchLevels_ApplyingBranchId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Return_ChangeAdd_Apps_BranchLevels_RecievingBranchId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Return_ChangeAdd_Apps_Users_AuditorId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Return_ChangeAdd_Apps_Users_RegisterId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Return_ChangeAddWaybillPrints_BranchLevels_PrintBranchId",
                table: "Return_ChangeAddWaybillPrints");

            migrationBuilder.DropForeignKey(
                name: "FK_Return_ChangeAddWaybillPrints_Users_PrinterId",
                table: "Return_ChangeAddWaybillPrints");

            migrationBuilder.DropForeignKey(
                name: "FK_Scans_Users_CreatorId",
                table: "Scans");

            migrationBuilder.DropForeignKey(
                name: "FK_Scans_Users_ModifiedId",
                table: "Scans");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketReplyImages_Tickets_TicketNumber",
                table: "TicketReplyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Areas_ReceiverAddressId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_BranchLevels_RegisterBrId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_RegisterId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentCode",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ModifiedBy",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WaybillReprints_Users_PrinterId",
                table: "WaybillReprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Users_CreatorId",
                table: "Zones");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Users_ModifiedId",
                table: "Zones");

            migrationBuilder.DropTable(
                name: "ClientQuotation");

            migrationBuilder.DropIndex(
                name: "IX_Zones_CreatorId",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Zones_ModifiedId",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_WaybillReprints_PrinterId",
                table: "WaybillReprints");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ReceiverAddressId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_RegisterBrId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_RegisterId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Scans_CreatorId",
                table: "Scans");

            migrationBuilder.DropIndex(
                name: "IX_Scans_ModifiedId",
                table: "Scans");

            migrationBuilder.DropIndex(
                name: "IX_Return_ChangeAddWaybillPrints_PrintBranchId",
                table: "Return_ChangeAddWaybillPrints");

            migrationBuilder.DropIndex(
                name: "IX_Return_ChangeAddWaybillPrints_PrinterId",
                table: "Return_ChangeAddWaybillPrints");

            migrationBuilder.DropIndex(
                name: "IX_Return_ChangeAdd_Apps_ApplyingBranchId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropIndex(
                name: "IX_Return_ChangeAdd_Apps_AuditorId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropIndex(
                name: "IX_Return_ChangeAdd_Apps_RecievingBranchId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropIndex(
                name: "IX_Return_ChangeAdd_Apps_RegisterId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_ClientCode",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_CreatorId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_ModifiedId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_CreatorId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_ModifiedId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Positions_CreatorId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_ModifiedId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryCourierId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PickupCourierId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Order_Scans_DeliveryCourierId",
                table: "Order_Scans");

            migrationBuilder.DropIndex(
                name: "IX_Order_Scans_PickupCourierId",
                table: "Order_Scans");

            migrationBuilder.DropIndex(
                name: "IX_Order_Scans_PreviousBranchId",
                table: "Order_Scans");

            migrationBuilder.DropIndex(
                name: "IX_Order_Scans_ScannerId",
                table: "Order_Scans");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreatorId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ModifiedId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_COD_FOD_Applications_ApplyingBranchId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropIndex(
                name: "IX_COD_FOD_Applications_AuditorId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropIndex(
                name: "IX_COD_FOD_Applications_RecievingBranchId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropIndex(
                name: "IX_COD_FOD_Applications_RegisterId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropIndex(
                name: "IX_COD_Collections_CollectorId",
                table: "COD_Collections");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatorId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ModifiedId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_SalesPersonId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Cash_FODCollections_CollectorId",
                table: "Cash_FODCollections");

            migrationBuilder.DropIndex(
                name: "IX_BranchLevels_CreatorId",
                table: "BranchLevels");

            migrationBuilder.DropIndex(
                name: "IX_BranchLevels_ModifiedId",
                table: "BranchLevels");

            migrationBuilder.DropIndex(
                name: "IX_BranchLevels_PrincipalId",
                table: "BranchLevels");

            migrationBuilder.DropIndex(
                name: "IX_Abnormals_RegisterId",
                table: "Abnormals");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReceiverAddressId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RecieverAddressId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RegisterBrId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PrintBranchId",
                table: "Return_ChangeAddWaybillPrints");

            migrationBuilder.DropColumn(
                name: "ApplyingBranchId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropColumn(
                name: "RecievingBranchId",
                table: "Return_ChangeAdd_Apps");

            migrationBuilder.DropColumn(
                name: "ClientCode",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DeliveryCourierId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickupCourierId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PreviousBranchId",
                table: "Order_Scans");

            migrationBuilder.DropColumn(
                name: "ApplyingBranchId",
                table: "COD_FOD_Applications");

            migrationBuilder.DropColumn(
                name: "RecievingBranchId",
                table: "COD_FOD_Applications");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                schema: "Security",
                table: "Users",
                newName: "ModifierId");

            migrationBuilder.RenameColumn(
                name: "DepartmentCode",
                schema: "Security",
                table: "Users",
                newName: "BranchCode");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ModifiedBy",
                schema: "Security",
                table: "Users",
                newName: "IX_Users_ModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_DepartmentCode",
                schema: "Security",
                table: "Users",
                newName: "IX_Users_BranchCode");

            migrationBuilder.RenameColumn(
                name: "TicketNumber",
                table: "TicketReplyImages",
                newName: "TicketReplyId");

            migrationBuilder.RenameColumn(
                name: "Default",
                table: "SenderAddressBooks",
                newName: "IsDefault");

            migrationBuilder.RenameColumn(
                name: "Default",
                table: "ReceiverAddressBooks",
                newName: "IsDefault");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Zones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Zones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PrinterId",
                table: "WaybillReprints",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Scans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Scans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PrinterId",
                table: "Return_ChangeAddWaybillPrints",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "Return_ChangeAdd_Apps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditorId",
                table: "Return_ChangeAdd_Apps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ScannerId",
                table: "Order_Scans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PickupCourierId",
                table: "Order_Scans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCourierId",
                table: "Order_Scans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "COD_FOD_Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditorId",
                table: "COD_FOD_Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CollectorId",
                table: "COD_Collections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SalesPersonId",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CollectorId",
                table: "Cash_FODCollections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PrincipalId",
                table: "BranchLevels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "BranchLevels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "BranchLevels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "Abnormals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "ClientQuotations",
                columns: table => new
                {
                    ClientCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuotationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientQuotations", x => new { x.QuotationId, x.ClientCode });
                    table.ForeignKey(
                        name: "FK_ClientQuotations_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientQuotations_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketReply",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReplyText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReplyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketReply_Tickets_TicketNumber",
                        column: x => x.TicketNumber,
                        principalTable: "Tickets",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientQuotations_ClientCode",
                table: "ClientQuotations",
                column: "ClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReply_TicketNumber",
                table: "TicketReply",
                column: "TicketNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReplyImages_TicketReply_TicketReplyId",
                table: "TicketReplyImages",
                column: "TicketReplyId",
                principalTable: "TicketReply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BranchLevels_BranchCode",
                schema: "Security",
                table: "Users",
                column: "BranchCode",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ModifierId",
                schema: "Security",
                table: "Users",
                column: "ModifierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReplyImages_TicketReply_TicketReplyId",
                table: "TicketReplyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_BranchLevels_BranchCode",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ModifierId",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ClientQuotations");

            migrationBuilder.DropTable(
                name: "TicketReply");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Security",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ModifierId",
                schema: "Security",
                table: "Users",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "BranchCode",
                schema: "Security",
                table: "Users",
                newName: "DepartmentCode");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ModifierId",
                schema: "Security",
                table: "Users",
                newName: "IX_Users_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BranchCode",
                schema: "Security",
                table: "Users",
                newName: "IX_Users_DepartmentCode");

            migrationBuilder.RenameColumn(
                name: "TicketReplyId",
                table: "TicketReplyImages",
                newName: "TicketNumber");

            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "SenderAddressBooks",
                newName: "Default");

            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "ReceiverAddressBooks",
                newName: "Default");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Zones",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Zones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PrinterId",
                table: "WaybillReprints",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverAddressId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecieverAddressId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisterBrId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Scans",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Scans",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PrinterId",
                table: "Return_ChangeAddWaybillPrints",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PrintBranchId",
                table: "Return_ChangeAddWaybillPrints",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "Return_ChangeAdd_Apps",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditorId",
                table: "Return_ChangeAdd_Apps",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplyingBranchId",
                table: "Return_ChangeAdd_Apps",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecievingBranchId",
                table: "Return_ChangeAdd_Apps",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Quotations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Quotations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ClientCode",
                table: "Quotations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "ProductTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "ProductTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Positions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Positions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCourierId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PickupCourierId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ScannerId",
                table: "Order_Scans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PickupCourierId",
                table: "Order_Scans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCourierId",
                table: "Order_Scans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousBranchId",
                table: "Order_Scans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "COD_FOD_Applications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditorId",
                table: "COD_FOD_Applications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplyingBranchId",
                table: "COD_FOD_Applications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecievingBranchId",
                table: "COD_FOD_Applications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CollectorId",
                table: "COD_Collections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SalesPersonId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CollectorId",
                table: "Cash_FODCollections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PrincipalId",
                table: "BranchLevels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedId",
                table: "BranchLevels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "BranchLevels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "Abnormals",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "IX_Zones_CreatorId",
                table: "Zones",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ModifiedId",
                table: "Zones",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillReprints_PrinterId",
                table: "WaybillReprints",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReceiverAddressId",
                table: "Tickets",
                column: "ReceiverAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RegisterBrId",
                table: "Tickets",
                column: "RegisterBrId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RegisterId",
                table: "Tickets",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Scans_CreatorId",
                table: "Scans",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Scans_ModifiedId",
                table: "Scans",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAddWaybillPrints_PrintBranchId",
                table: "Return_ChangeAddWaybillPrints",
                column: "PrintBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAddWaybillPrints_PrinterId",
                table: "Return_ChangeAddWaybillPrints",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_ApplyingBranchId",
                table: "Return_ChangeAdd_Apps",
                column: "ApplyingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_AuditorId",
                table: "Return_ChangeAdd_Apps",
                column: "AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_RecievingBranchId",
                table: "Return_ChangeAdd_Apps",
                column: "RecievingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_RegisterId",
                table: "Return_ChangeAdd_Apps",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ClientCode",
                table: "Quotations",
                column: "ClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CreatorId",
                table: "Quotations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ModifiedId",
                table: "Quotations",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CreatorId",
                table: "ProductTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ModifiedId",
                table: "ProductTypes",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatorId",
                table: "Positions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ModifiedId",
                table: "Positions",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryCourierId",
                table: "Orders",
                column: "DeliveryCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickupCourierId",
                table: "Orders",
                column: "PickupCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_DeliveryCourierId",
                table: "Order_Scans",
                column: "DeliveryCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_PickupCourierId",
                table: "Order_Scans",
                column: "PickupCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_PreviousBranchId",
                table: "Order_Scans",
                column: "PreviousBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_ScannerId",
                table: "Order_Scans",
                column: "ScannerId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatorId",
                table: "Departments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ModifiedId",
                table: "Departments",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_ApplyingBranchId",
                table: "COD_FOD_Applications",
                column: "ApplyingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_AuditorId",
                table: "COD_FOD_Applications",
                column: "AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_RecievingBranchId",
                table: "COD_FOD_Applications",
                column: "RecievingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_RegisterId",
                table: "COD_FOD_Applications",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_Collections_CollectorId",
                table: "COD_Collections",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatorId",
                table: "Clients",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ModifiedId",
                table: "Clients",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SalesPersonId",
                table: "Clients",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Cash_FODCollections_CollectorId",
                table: "Cash_FODCollections",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_CreatorId",
                table: "BranchLevels",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_ModifiedId",
                table: "BranchLevels",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_PrincipalId",
                table: "BranchLevels",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_RegisterId",
                table: "Abnormals",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientQuotation_QuotationsId",
                table: "ClientQuotation",
                column: "QuotationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_Users_RegisterId",
                table: "Abnormals",
                column: "RegisterId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_CreatorId",
                table: "BranchLevels",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_ModifiedId",
                table: "BranchLevels",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_PrincipalId",
                table: "BranchLevels",
                column: "PrincipalId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cash_FODCollections_Users_CollectorId",
                table: "Cash_FODCollections",
                column: "CollectorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatorId",
                table: "Clients",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_ModifiedId",
                table: "Clients",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_SalesPersonId",
                table: "Clients",
                column: "SalesPersonId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_Collections_Users_CollectorId",
                table: "COD_Collections",
                column: "CollectorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_FOD_Applications_BranchLevels_ApplyingBranchId",
                table: "COD_FOD_Applications",
                column: "ApplyingBranchId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_FOD_Applications_BranchLevels_RecievingBranchId",
                table: "COD_FOD_Applications",
                column: "RecievingBranchId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_FOD_Applications_Users_AuditorId",
                table: "COD_FOD_Applications",
                column: "AuditorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_FOD_Applications_Users_RegisterId",
                table: "COD_FOD_Applications",
                column: "RegisterId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreatorId",
                table: "Departments",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ModifiedId",
                table: "Departments",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_BranchLevels_PreviousBranchId",
                table: "Order_Scans",
                column: "PreviousBranchId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_Users_DeliveryCourierId",
                table: "Order_Scans",
                column: "DeliveryCourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_Users_PickupCourierId",
                table: "Order_Scans",
                column: "PickupCourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_Users_ScannerId",
                table: "Order_Scans",
                column: "ScannerId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_DeliveryCourierId",
                table: "Orders",
                column: "DeliveryCourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_PickupCourierId",
                table: "Orders",
                column: "PickupCourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_CreatorId",
                table: "Positions",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_ModifiedId",
                table: "Positions",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Users_CreatorId",
                table: "ProductTypes",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Users_ModifiedId",
                table: "ProductTypes",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Clients_ClientCode",
                table: "Quotations",
                column: "ClientCode",
                principalTable: "Clients",
                principalColumn: "ClientCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_CreatorId",
                table: "Quotations",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_ModifiedId",
                table: "Quotations",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Return_ChangeAdd_Apps_BranchLevels_ApplyingBranchId",
                table: "Return_ChangeAdd_Apps",
                column: "ApplyingBranchId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Return_ChangeAdd_Apps_BranchLevels_RecievingBranchId",
                table: "Return_ChangeAdd_Apps",
                column: "RecievingBranchId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Return_ChangeAdd_Apps_Users_AuditorId",
                table: "Return_ChangeAdd_Apps",
                column: "AuditorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Return_ChangeAdd_Apps_Users_RegisterId",
                table: "Return_ChangeAdd_Apps",
                column: "RegisterId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Return_ChangeAddWaybillPrints_BranchLevels_PrintBranchId",
                table: "Return_ChangeAddWaybillPrints",
                column: "PrintBranchId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Return_ChangeAddWaybillPrints_Users_PrinterId",
                table: "Return_ChangeAddWaybillPrints",
                column: "PrinterId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scans_Users_CreatorId",
                table: "Scans",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scans_Users_ModifiedId",
                table: "Scans",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReplyImages_Tickets_TicketNumber",
                table: "TicketReplyImages",
                column: "TicketNumber",
                principalTable: "Tickets",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Areas_ReceiverAddressId",
                table: "Tickets",
                column: "ReceiverAddressId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_BranchLevels_RegisterBrId",
                table: "Tickets",
                column: "RegisterBrId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_RegisterId",
                table: "Tickets",
                column: "RegisterId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentCode",
                schema: "Security",
                table: "Users",
                column: "DepartmentCode",
                principalTable: "Departments",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ModifiedBy",
                schema: "Security",
                table: "Users",
                column: "ModifiedBy",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaybillReprints_Users_PrinterId",
                table: "WaybillReprints",
                column: "PrinterId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Users_CreatorId",
                table: "Zones",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Users_ModifiedId",
                table: "Zones",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
