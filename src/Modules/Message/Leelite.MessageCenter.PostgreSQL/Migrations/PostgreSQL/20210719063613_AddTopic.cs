using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Leelite.Modules.MessageCenter.Migrations.PostgreSQL
{
    public partial class AddTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Message_Type",
                newName: "Topic");

            migrationBuilder.AddColumn<long>(
                name: "SessionId",
                table: "Message",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Message_Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Code = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message_Topic", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message_Topic");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "Topic",
                table: "Message_Type",
                newName: "Icon");
        }
    }
}
