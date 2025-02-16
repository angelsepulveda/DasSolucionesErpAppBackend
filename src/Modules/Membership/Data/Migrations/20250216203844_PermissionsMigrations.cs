using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Data.Migrations
{
    /// <inheritdoc />
    public partial class PermissionsMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsActions_Action",
                schema: "Membership",
                table: "permissions__actions");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsActions_Permission",
                schema: "Membership",
                table: "permissions__actions");

            migrationBuilder.DropForeignKey(
                name: "FK_permissions__actions_permissions_PermissionId1",
                schema: "Membership",
                table: "permissions__actions");

            migrationBuilder.DropIndex(
                name: "IX_permissions__actions_PermissionId1",
                schema: "Membership",
                table: "permissions__actions");

            migrationBuilder.DropColumn(
                name: "PermissionId1",
                schema: "Membership",
                table: "permissions__actions");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions__actions_actions_action_id",
                schema: "Membership",
                table: "permissions__actions",
                column: "action_id",
                principalSchema: "Membership",
                principalTable: "actions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_permissions__actions_permissions_permission_id",
                schema: "Membership",
                table: "permissions__actions",
                column: "permission_id",
                principalSchema: "Membership",
                principalTable: "permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions__actions_actions_action_id",
                schema: "Membership",
                table: "permissions__actions");

            migrationBuilder.DropForeignKey(
                name: "FK_permissions__actions_permissions_permission_id",
                schema: "Membership",
                table: "permissions__actions");

            migrationBuilder.AddColumn<string>(
                name: "PermissionId1",
                schema: "Membership",
                table: "permissions__actions",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissions__actions_PermissionId1",
                schema: "Membership",
                table: "permissions__actions",
                column: "PermissionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsActions_Action",
                schema: "Membership",
                table: "permissions__actions",
                column: "action_id",
                principalSchema: "Membership",
                principalTable: "actions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsActions_Permission",
                schema: "Membership",
                table: "permissions__actions",
                column: "permission_id",
                principalSchema: "Membership",
                principalTable: "permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_permissions__actions_permissions_PermissionId1",
                schema: "Membership",
                table: "permissions__actions",
                column: "PermissionId1",
                principalSchema: "Membership",
                principalTable: "permissions",
                principalColumn: "id");
        }
    }
}
