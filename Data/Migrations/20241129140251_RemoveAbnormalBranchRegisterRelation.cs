using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemoveAbnormalBranchRegisterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abnormals_BranchLevels_RegisterBrId",
                table: "Abnormals");

            migrationBuilder.DropIndex(
                name: "IX_Abnormals_RegisterBrId",
                table: "Abnormals");

            migrationBuilder.DropColumn(
                name: "RegisterBrId",
                table: "Abnormals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegisterBrId",
                table: "Abnormals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_RegisterBrId",
                table: "Abnormals",
                column: "RegisterBrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_BranchLevels_RegisterBrId",
                table: "Abnormals",
                column: "RegisterBrId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
