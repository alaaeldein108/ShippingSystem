using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddFirstSecondTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstSegmentCode = table.Column<int>(type: "int", nullable: false),
                    FirstSegmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalOrganizationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalOrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirstSegments_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecondSegments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstSegmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_SecondSegments_FirstSegments_FirstSegmentId",
                        column: x => x.FirstSegmentId,
                        principalTable: "FirstSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_AreaId",
                table: "FirstSegments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_AreaId",
                table: "SecondSegments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_BranchCode",
                table: "SecondSegments",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_FirstSegmentId",
                table: "SecondSegments",
                column: "FirstSegmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondSegments");

            migrationBuilder.DropTable(
                name: "FirstSegments");
        }
    }
}
