using Microsoft.EntityFrameworkCore.Migrations;

namespace Leelite.Modules.MessageCenter.Migrations.PostgreSQL
{
    public partial class AddPushRecordUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Message_Push_Record",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Message_Push_Record");
        }
    }
}
