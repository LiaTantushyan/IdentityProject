using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProj.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StatusForCompanyInitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 19, 11, 37, 33, 804, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Companies",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 19, 11, 37, 33, 804, DateTimeKind.Utc).AddTicks(2137));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Companies",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Companies");
        }
    }
}
