using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Leelite.Modules.Identity.Migrations.PostgreSQL
{
    public partial class InitialIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Identity_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserKeys",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KeyId = table.Column<string>(maxLength: 64, nullable: true),
                    PublicKey = table.Column<string>(maxLength: 1024, nullable: true),
                    SignatureRule = table.Column<string>(maxLength: 256, nullable: true),
                    SignatureData = table.Column<string>(maxLength: 1024, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NickName = table.Column<string>(maxLength: 256, nullable: true),
                    RealName = table.Column<string>(maxLength: 256, nullable: true),
                    Sex = table.Column<string>(maxLength: 1, nullable: true),
                    Birthday = table.Column<DateTimeOffset>(nullable: false),
                    IsReal = table.Column<bool>(nullable: false),
                    ProfilePicture = table.Column<string>(maxLength: 1024, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 1024, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 64, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(maxLength: 256, nullable: true),
                    Ethnicity = table.Column<string>(maxLength: 32, nullable: true),
                    Address = table.Column<string>(maxLength: 256, nullable: true),
                    IDNumber = table.Column<string>(maxLength: 32, nullable: true),
                    IssuingAuthority = table.Column<string>(maxLength: 64, nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<string>(nullable: true),
                    FeatureCode = table.Column<string>(nullable: true),
                    CreatorId = table.Column<long>(nullable: false),
                    Creator = table.Column<string>(maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<long>(nullable: false),
                    Modifier = table.Column<string>(maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity_RoleClaims_Identity_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Identity_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity_UserClaims_Identity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserFingerprints",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: false),
                    FingerName = table.Column<string>(maxLength: 64, nullable: true),
                    Fingerprint = table.Column<string>(maxLength: 1024, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserFingerprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity_UserFingerprints_Identity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserLogins",
                columns: table => new
                {
                    _loginProvider = table.Column<string>(nullable: false),
                    _providerKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(maxLength: 256, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserLogins", x => new { x._loginProvider, x._providerKey });
                    table.ForeignKey(
                        name: "FK_Identity_UserLogins_Identity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UserRole_UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Identity_UserRoles_Identity_Users_UserRole_UserId",
                        column: x => x.UserRole_UserId,
                        principalTable: "Identity_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Identity_UserRoles_Identity_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Identity_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    _loginProvider = table.Column<string>(nullable: false),
                    _name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(maxLength: 256, nullable: true),
                    UserToken_UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserTokens", x => new { x.UserId, x._loginProvider, x._name });
                    table.ForeignKey(
                        name: "FK_Identity_UserTokens_Identity_Users_UserToken_UserId",
                        column: x => x.UserToken_UserId,
                        principalTable: "Identity_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identity_RoleClaims_RoleId",
                table: "Identity_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Identity_Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserClaims_UserId",
                table: "Identity_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserFingerprints_UserId",
                table: "Identity_UserFingerprints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserLogins_UserId",
                table: "Identity_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserRoles_UserRole_UserId",
                table: "Identity_UserRoles",
                column: "UserRole_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserRoles_RoleId",
                table: "Identity_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Identity_Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Identity_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserTokens_UserToken_UserId",
                table: "Identity_UserTokens",
                column: "UserToken_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Identity_RoleClaims");

            migrationBuilder.DropTable(
                name: "Identity_UserClaims");

            migrationBuilder.DropTable(
                name: "Identity_UserFingerprints");

            migrationBuilder.DropTable(
                name: "Identity_UserKeys");

            migrationBuilder.DropTable(
                name: "Identity_UserLogins");

            migrationBuilder.DropTable(
                name: "Identity_UserRoles");

            migrationBuilder.DropTable(
                name: "Identity_UserTokens");

            migrationBuilder.DropTable(
                name: "Identity_Roles");

            migrationBuilder.DropTable(
                name: "Identity_Users");
        }
    }
}
