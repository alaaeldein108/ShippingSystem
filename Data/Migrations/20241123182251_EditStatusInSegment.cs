using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class EditStatusInSegment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FirstSegments");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "SecondSegments",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "FirstSegments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "FirstSegments");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SecondSegments",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FirstSegments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
