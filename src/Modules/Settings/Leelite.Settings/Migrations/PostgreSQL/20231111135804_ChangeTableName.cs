using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leelite.Settings.Migrations.PostgreSQL
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings_SettingValue",
                table: "Settings_SettingValue");

            migrationBuilder.RenameTable(
                name: "Settings_SettingValue",
                newName: "Settings_SettingValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings_SettingValues",
                table: "Settings_SettingValues",
                columns: new[] { "TenantId", "UserId", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings_SettingValues",
                table: "Settings_SettingValues");

            migrationBuilder.RenameTable(
                name: "Settings_SettingValues",
                newName: "Settings_SettingValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings_SettingValue",
                table: "Settings_SettingValue",
                columns: new[] { "TenantId", "UserId", "Name" });
        }
    }
}
