using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActionMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                schema: "Membership",
                table: "Modules");

            migrationBuilder.RenameTable(
                name: "Modules",
                schema: "Membership",
                newName: "modules",
                newSchema: "Membership");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Membership",
                table: "modules",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Membership",
                table: "modules",
                newName: "id");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                schema: "Membership",
                table: "modules",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "Membership",
                table: "modules",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "Membership",
                table: "modules",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modules",
                schema: "Membership",
                table: "modules",
                column: "id");

            migrationBuilder.CreateTable(
                name: "actions",
                schema: "Membership",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actions",
                schema: "Membership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modules",
                schema: "Membership",
                table: "modules");

            migrationBuilder.RenameTable(
                name: "modules",
                schema: "Membership",
                newName: "Modules",
                newSchema: "Membership");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "Membership",
                table: "Modules",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "Membership",
                table: "Modules",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Membership",
                table: "Modules",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                schema: "Membership",
                table: "Modules",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "Membership",
                table: "Modules",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                schema: "Membership",
                table: "Modules",
                column: "Id");
        }
    }
}
