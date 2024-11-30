using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class EditTablesTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReplyImages",
                table: "TicketReplyImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TicketReplyImages");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReplyImages",
                table: "TicketReplyImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply",
                columns: new[] { "TicketNumber", "ReplyText", "ReplyTime" });
        }
    }
}
