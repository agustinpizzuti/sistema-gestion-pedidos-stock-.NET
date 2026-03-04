using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addsumOrSubstractStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sumOrSubstractStock",
                table: "stocksMovement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sumOrSubstractStock",
                table: "stocksMovement");
        }
    }
}
