using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddClientCustomerTypeAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Clients",
                type: "datetime2",
                nullable: true);
        }
    }
}
