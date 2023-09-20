using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProj.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DefaultDateTimeValueInitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 19, 11, 37, 33, 804, DateTimeKind.Utc).AddTicks(2137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 19, 11, 37, 33, 804, DateTimeKind.Utc).AddTicks(2052));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 19, 11, 37, 33, 804, DateTimeKind.Utc).AddTicks(2137),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 19, 11, 37, 33, 804, DateTimeKind.Utc).AddTicks(2052),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
