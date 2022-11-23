using Microsoft.EntityFrameworkCore.Migrations;

namespace Leelite.Settings.Migrations.PostgreSQL
{
    public partial class InitialSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings_SettingValue",
                columns: table => new
                {
                    TenantId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings_SettingValue", x => new { x.TenantId, x.UserId, x.Name });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings_SettingValue");
        }
    }
}
