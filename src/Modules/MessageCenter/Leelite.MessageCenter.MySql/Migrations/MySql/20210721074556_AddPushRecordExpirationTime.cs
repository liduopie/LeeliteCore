using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leelite.Modules.MessageCenter.Migrations.MySql
{
    public partial class AddPushRecordExpirationTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PushState",
                table: "Message_Push_Record");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationTime",
                table: "Message_Push_Record",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Message_Push_Record",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationTime",
                table: "Message_Push_Record");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Message_Push_Record");

            migrationBuilder.AddColumn<bool>(
                name: "PushState",
                table: "Message_Push_Record",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
