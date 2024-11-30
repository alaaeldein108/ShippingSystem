using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddTableInCS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReply_Tickets_TicketNumber",
                table: "TicketReply");

            migrationBuilder.DropTable(
                name: "TicketReplyImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply");

            migrationBuilder.RenameTable(
                name: "TicketReply",
                newName: "TicketReplies");

            migrationBuilder.RenameIndex(
                name: "IX_TicketReply_TicketNumber",
                table: "TicketReplies",
                newName: "IX_TicketReplies_TicketNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReplies",
                table: "TicketReplies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TicketReplyAttachments",
                columns: table => new
                {
                    TicketReplyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReplyAttachments", x => new { x.TicketReplyId, x.PictureUrl });
                    table.ForeignKey(
                        name: "FK_TicketReplyAttachments_TicketReplies_TicketReplyId",
                        column: x => x.TicketReplyId,
                        principalTable: "TicketReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReplies_Tickets_TicketNumber",
                table: "TicketReplies",
                column: "TicketNumber",
                principalTable: "Tickets",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReplies_Tickets_TicketNumber",
                table: "TicketReplies");

            migrationBuilder.DropTable(
                name: "TicketReplyAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReplies",
                table: "TicketReplies");

            migrationBuilder.RenameTable(
                name: "TicketReplies",
                newName: "TicketReply");

            migrationBuilder.RenameIndex(
                name: "IX_TicketReplies_TicketNumber",
                table: "TicketReply",
                newName: "IX_TicketReply_TicketNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TicketReplyImages",
                columns: table => new
                {
                    TicketReplyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReplyImages", x => new { x.TicketReplyId, x.PictureUrl });
                    table.ForeignKey(
                        name: "FK_TicketReplyImages_TicketReply_TicketReplyId",
                        column: x => x.TicketReplyId,
                        principalTable: "TicketReply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReply_Tickets_TicketNumber",
                table: "TicketReply",
                column: "TicketNumber",
                principalTable: "Tickets",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
