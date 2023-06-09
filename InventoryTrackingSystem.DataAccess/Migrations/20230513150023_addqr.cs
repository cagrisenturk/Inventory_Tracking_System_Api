using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addqr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GetQrCode",
                table: "Inventories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PutQrCode",
                table: "Inventories",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GetQrCode",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "PutQrCode",
                table: "Inventories");
        }
    }
}
