using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSystem.Data.Migrations
{
    public partial class UpdateIncomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpDate",
                table: "Income",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Income",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpDate",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Income");
        }
    }
}
