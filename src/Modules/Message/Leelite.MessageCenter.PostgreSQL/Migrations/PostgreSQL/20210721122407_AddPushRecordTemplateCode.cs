using Microsoft.EntityFrameworkCore.Migrations;

namespace Leelite.Modules.MessageCenter.Migrations.PostgreSQL
{
    public partial class AddPushRecordTemplateCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TemplateCode",
                table: "Message_Push_Record",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateCode",
                table: "Message_Push_Record");
        }
    }
}
