using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class removeFirstSecondTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondSegments");

            migrationBuilder.DropTable(
                name: "FirstSegments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstSegments",
                columns: table => new
                {
                    BaggingNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BaggingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalOrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalOrganizationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstSegments", x => x.BaggingNumber);
                    table.ForeignKey(
                        name: "FK_FirstSegments_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirstSegments_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirstSegments_Users_ModifiedId",
                        column: x => x.ModifiedId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SecondSegments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstSegmentCode = table.Column<int>(type: "int", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecendSegmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondSegments_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecondSegments_BranchLevels_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecondSegments_FirstSegments_FirstSegmentCode",
                        column: x => x.FirstSegmentCode,
                        principalTable: "FirstSegments",
                        principalColumn: "BaggingNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecondSegments_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecondSegments_Users_ModifiedId",
                        column: x => x.ModifiedId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_AreaId",
                table: "FirstSegments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_CreatorId",
                table: "FirstSegments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_ModifiedId",
                table: "FirstSegments",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_AreaId",
                table: "SecondSegments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_BranchCode",
                table: "SecondSegments",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_CreatorId",
                table: "SecondSegments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_FirstSegmentCode",
                table: "SecondSegments",
                column: "FirstSegmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_ModifiedId",
                table: "SecondSegments",
                column: "ModifiedId");
        }
    }
}
