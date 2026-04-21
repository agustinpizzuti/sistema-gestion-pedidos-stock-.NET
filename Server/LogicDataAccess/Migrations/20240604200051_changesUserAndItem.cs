using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changesUserAndItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stock",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "admi",
                table: "users",
                newName: "isManager");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "users");

            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "isManager",
                table: "users",
                newName: "admi");

            migrationBuilder.AddColumn<int>(
                name: "stock",
                table: "items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
