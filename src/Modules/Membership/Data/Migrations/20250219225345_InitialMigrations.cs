using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Membership");

            migrationBuilder.CreateTable(
                name: "actions",
                schema: "Membership",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                schema: "Membership",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "Membership",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    module_id = table.Column<string>(type: "char(36)", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    key = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sections",
                schema: "Membership",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    key = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sections", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions__actions",
                schema: "Membership",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(36)", nullable: false),
                    permission_id = table.Column<string>(type: "char(36)", nullable: false),
                    action_id = table.Column<string>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions__actions", x => x.id);
                    table.ForeignKey(
                        name: "FK_permissions__actions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "Membership",
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permissions__actions_permission_id",
                schema: "Membership",
                table: "permissions__actions",
                column: "permission_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actions",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "modules",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "permissions__actions",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "sections",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "Membership");
        }
    }
}
