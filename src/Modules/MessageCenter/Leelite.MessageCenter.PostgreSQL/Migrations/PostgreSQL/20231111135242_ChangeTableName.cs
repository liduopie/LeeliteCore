using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leelite.MessageCenter.PostgreSQL.Migrations.PostgreSQL
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Type",
                table: "MessageCenter_Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Topic",
                table: "MessageCenter_Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Template",
                table: "MessageCenter_Template");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Session",
                table: "MessageCenter_Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Record",
                table: "MessageCenter_Record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Platform",
                table: "MessageCenter_Platform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Message",
                table: "MessageCenter_Message");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Type",
                newName: "MessageCenter_Types");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Topic",
                newName: "MessageCenter_Topics");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Template",
                newName: "MessageCenter_Templates");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Session",
                newName: "MessageCenter_Sessions");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Record",
                newName: "MessageCenter_Records");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Platform",
                newName: "MessageCenter_Platforms");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Message",
                newName: "MessageCenter_Messages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Types",
                table: "MessageCenter_Types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Topics",
                table: "MessageCenter_Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Templates",
                table: "MessageCenter_Templates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Sessions",
                table: "MessageCenter_Sessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Records",
                table: "MessageCenter_Records",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Platforms",
                table: "MessageCenter_Platforms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Messages",
                table: "MessageCenter_Messages",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Types",
                table: "MessageCenter_Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Topics",
                table: "MessageCenter_Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Templates",
                table: "MessageCenter_Templates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Sessions",
                table: "MessageCenter_Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Records",
                table: "MessageCenter_Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Platforms",
                table: "MessageCenter_Platforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCenter_Messages",
                table: "MessageCenter_Messages");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Types",
                newName: "MessageCenter_Type");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Topics",
                newName: "MessageCenter_Topic");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Templates",
                newName: "MessageCenter_Template");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Sessions",
                newName: "MessageCenter_Session");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Records",
                newName: "MessageCenter_Record");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Platforms",
                newName: "MessageCenter_Platform");

            migrationBuilder.RenameTable(
                name: "MessageCenter_Messages",
                newName: "MessageCenter_Message");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Type",
                table: "MessageCenter_Type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Topic",
                table: "MessageCenter_Topic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Template",
                table: "MessageCenter_Template",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Session",
                table: "MessageCenter_Session",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Record",
                table: "MessageCenter_Record",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Platform",
                table: "MessageCenter_Platform",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCenter_Message",
                table: "MessageCenter_Message",
                column: "Id");
        }
    }
}
