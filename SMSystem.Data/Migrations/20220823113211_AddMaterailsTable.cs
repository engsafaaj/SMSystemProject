using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSystem.Data.Migrations
{
    public partial class AddMaterailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    InCome = table.Column<double>(type: "float", nullable: false),
                    OutCome = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    StoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materails_Stores_StoresId",
                        column: x => x.StoresId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materails_StoresId",
                table: "Materails",
                column: "StoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materails");
        }
    }
}
