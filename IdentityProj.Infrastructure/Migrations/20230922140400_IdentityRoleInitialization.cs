using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityProj.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleInitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "d6c85780-21bb-418e-9a87-616b3b419991", "SuperAdmin", "SUPERADMIN" },
                    { 2, "dd9dcfaf-7287-4ce4-b44e-eba905e1b8f8", "CompanyAdmin", "COMPANYADMIN" },
                    { 3, "ef8cc47c-315f-445e-b5b7-c6ca2863fb58", "Other", "OTHER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
