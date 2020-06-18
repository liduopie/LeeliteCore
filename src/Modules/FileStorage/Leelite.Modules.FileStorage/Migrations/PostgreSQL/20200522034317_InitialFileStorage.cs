using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leelite.Modules.FileStorage.Migrations.PostgreSQL
{
    public partial class InitialFileStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileStorage_FileItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<long>(nullable: false),
                    ModuleCode = table.Column<string>(maxLength: 32, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(maxLength: 1024, nullable: true),
                    Length = table.Column<long>(nullable: false),
                    MD5 = table.Column<string>(maxLength: 32, nullable: true),
                    CreatorId = table.Column<long>(nullable: false),
                    Creator = table.Column<string>(maxLength: 32, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<long>(nullable: false),
                    Modifier = table.Column<string>(maxLength: 32, nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Visits = table.Column<long>(nullable: false),
                    LastVisitTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorage_FileItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileStorage_FileItem");
        }
    }
}
