using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MovementStockAndType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movementsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movementsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stocksMovement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateOfMovement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    itemID = table.Column<int>(type: "int", nullable: false),
                    mailUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movementTypeID = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocksMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stocksMovement_items_itemID",
                        column: x => x.itemID,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stocksMovement_movementsType_movementTypeID",
                        column: x => x.movementTypeID,
                        principalTable: "movementsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movementsType_name",
                table: "movementsType",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stocksMovement_itemID",
                table: "stocksMovement",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_stocksMovement_movementTypeID",
                table: "stocksMovement",
                column: "movementTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stocksMovement");

            migrationBuilder.DropTable(
                name: "movementsType");
        }
    }
}
