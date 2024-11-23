using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class EditBranchLeve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_BranchLevels_SuperId",
                table: "BranchLevels");

            migrationBuilder.DropIndex(
                name: "IX_BranchLevels_SuperId",
                table: "BranchLevels");

            migrationBuilder.DropColumn(
                name: "SuperId",
                table: "BranchLevels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SuperId",
                table: "BranchLevels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_SuperId",
                table: "BranchLevels",
                column: "SuperId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_BranchLevels_SuperId",
                table: "BranchLevels",
                column: "SuperId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
