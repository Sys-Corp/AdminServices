using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAdminStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GN");

            migrationBuilder.CreateTable(
                name: "admin_status",
                schema: "GN",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_status", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "GN",
                table: "admin_status",
                columns: new[] { "id", "created_at", "description", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 12, 22, 15, 23, 630, DateTimeKind.Local).AddTicks(6855), "Active", new DateTime(2025, 4, 12, 22, 15, 23, 630, DateTimeKind.Local).AddTicks(6864) },
                    { 2, new DateTime(2025, 4, 12, 22, 15, 23, 630, DateTimeKind.Local).AddTicks(6864), "In Active", new DateTime(2025, 4, 12, 22, 15, 23, 630, DateTimeKind.Local).AddTicks(6865) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_status",
                schema: "GN");
        }
    }
}
