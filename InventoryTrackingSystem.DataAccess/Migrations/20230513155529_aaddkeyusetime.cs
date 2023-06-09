using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InventoryTrackingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class aaddkeyusetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "InventoryUseTimes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "InventoryUseTimes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "InventoryUseTimes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryUseTimes",
                table: "InventoryUseTimes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryUseTimes",
                table: "InventoryUseTimes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InventoryUseTimes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "InventoryUseTimes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "InventoryUseTimes");
        }
    }
}
