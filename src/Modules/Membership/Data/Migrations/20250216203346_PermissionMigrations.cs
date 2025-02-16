using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Data.Migrations
{
    /// <inheritdoc />
    public partial class PermissionMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.ForeignKey(
                        name: "FK_Permissions_Module",
                        column: x => x.module_id,
                        principalSchema: "Membership",
                        principalTable: "modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "permissions__actions",
                schema: "Membership",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(36)", nullable: false),
                    permission_id = table.Column<string>(type: "char(36)", nullable: false),
                    action_id = table.Column<string>(type: "char(36)", nullable: false),
                    PermissionId1 = table.Column<string>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions__actions", x => x.id);
                    table.ForeignKey(
                        name: "FK_PermissionsActions_Action",
                        column: x => x.action_id,
                        principalSchema: "Membership",
                        principalTable: "actions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionsActions_Permission",
                        column: x => x.permission_id,
                        principalSchema: "Membership",
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_permissions__actions_permissions_PermissionId1",
                        column: x => x.PermissionId1,
                        principalSchema: "Membership",
                        principalTable: "permissions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_permissions_module_id",
                schema: "Membership",
                table: "permissions",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissions__actions_action_id",
                schema: "Membership",
                table: "permissions__actions",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissions__actions_permission_id",
                schema: "Membership",
                table: "permissions__actions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissions__actions_PermissionId1",
                schema: "Membership",
                table: "permissions__actions",
                column: "PermissionId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permissions__actions",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "Membership");
        }
    }
}
