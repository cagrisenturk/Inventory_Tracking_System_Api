using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dropverify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
