using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class EditTableWithAddStatusProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReplyImages_TicketReply_TicketReplyId",
                table: "TicketReplyImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReplyImages",
                table: "TicketReplyImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply");

            migrationBuilder.DropIndex(
                name: "IX_TicketReply_TicketNumber",
                table: "TicketReply");

            migrationBuilder.DropColumn(
                name: "TicketReplyId",
                table: "TicketReplyImages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TicketReply");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Scans",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "EnableStatus",
                table: "Quotations",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "IsEnable",
                table: "Clients",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "BranchStatus",
                table: "BranchLevels",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Zones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TicketSubQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "TicketReplyImages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TicketReplyImages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ReplyText",
                table: "TicketReply",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TicketMainQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "COD_FOD_Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AbnormalSubReasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AbnormalMainReasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReplyImages",
                table: "TicketReplyImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply",
                columns: new[] { "TicketNumber", "ReplyText", "ReplyTime" });

            migrationBuilder.CreateTable(
                name: "TicketAttachements",
                columns: table => new
                {
                    TicketNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttachmentURL = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAttachements", x => new { x.TicketNumber, x.AttachmentURL });
                    table.ForeignKey(
                        name: "FK_TicketAttachements_Tickets_TicketNumber",
                        column: x => x.TicketNumber,
                        principalTable: "Tickets",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketAttachements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReplyImages",
                table: "TicketReplyImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TicketSubQuestions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TicketReplyImages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TicketMainQuestions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "COD_FOD_Applications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AbnormalSubReasons");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AbnormalMainReasons");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Scans",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Quotations",
                newName: "EnableStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Clients",
                newName: "IsEnable");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "BranchLevels",
                newName: "BranchStatus");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "TicketReplyImages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TicketReplyId",
                table: "TicketReplyImages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ReplyText",
                table: "TicketReply",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "TicketReply",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReplyImages",
                table: "TicketReplyImages",
                columns: new[] { "TicketReplyId", "PictureUrl" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply",
                column: "Id");

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
        }
    }
}
