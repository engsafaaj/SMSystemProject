using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSystem.Data.Migrations
{
    public partial class AddIncomTabl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReciptNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RectipImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaterailId = table.Column<int>(type: "int", nullable: false),
                    MaterailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Income_Materails_MaterailsId",
                        column: x => x.MaterailsId,
                        principalTable: "Materails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Income_MaterailsId",
                table: "Income",
                column: "MaterailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Income");
        }
    }
}
