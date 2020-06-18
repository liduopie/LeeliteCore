using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leelite.Modules.IdentityServer.Migrations.PostgreSQL.PersistedGrants
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityServer_DeviceFlowCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_DeviceFlowCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_DeviceFlowCodes_DeviceCode",
                table: "IdentityServer_DeviceFlowCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_DeviceFlowCodes_Expiration",
                table: "IdentityServer_DeviceFlowCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_PersistedGrants_Expiration",
                table: "IdentityServer_PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_PersistedGrants_SubjectId_ClientId_Type",
                table: "IdentityServer_PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityServer_DeviceFlowCodes");

            migrationBuilder.DropTable(
                name: "IdentityServer_PersistedGrants");
        }
    }
}
