using Microsoft.EntityFrameworkCore.Migrations;

namespace Leelite.MessageCenter.Migrations.MySql
{
    public partial class AddPushRecordTemplateCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TemplateCode",
                table: "Message_Push_Record",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateCode",
                table: "Message_Push_Record");
        }
    }
}
