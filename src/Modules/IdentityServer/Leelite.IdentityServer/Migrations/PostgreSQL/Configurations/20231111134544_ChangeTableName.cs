using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leelite.IdentityServer.Migrations.PostgreSQL.Configurations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiResourceClaim_IdentityServer_ApiResource_~",
                table: "IdentityServer_ApiResourceClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiResourceProperty_IdentityServer_ApiResour~",
                table: "IdentityServer_ApiResourceProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiResourceScope_IdentityServer_ApiResource_~",
                table: "IdentityServer_ApiResourceScope");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiResourceSecret_IdentityServer_ApiResource~",
                table: "IdentityServer_ApiResourceSecret");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiScopeClaim_IdentityServer_ApiScope_ScopeId",
                table: "IdentityServer_ApiScopeClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiScopeProperty_IdentityServer_ApiScope_Sco~",
                table: "IdentityServer_ApiScopeProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientClaim_IdentityServer_Client_ClientId",
                table: "IdentityServer_ClientClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientCorsOrigin_IdentityServer_Client_Clien~",
                table: "IdentityServer_ClientCorsOrigin");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientGrantType_IdentityServer_Client_Client~",
                table: "IdentityServer_ClientGrantType");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientIdPRestriction_IdentityServer_Client_C~",
                table: "IdentityServer_ClientIdPRestriction");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientPostLogoutRedirectUri_IdentityServer_C~",
                table: "IdentityServer_ClientPostLogoutRedirectUri");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientProperty_IdentityServer_Client_ClientId",
                table: "IdentityServer_ClientProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientRedirectUri_IdentityServer_Client_Clie~",
                table: "IdentityServer_ClientRedirectUri");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientScopes_IdentityServer_Client_ClientId",
                table: "IdentityServer_ClientScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientSecret_IdentityServer_Client_ClientId",
                table: "IdentityServer_ClientSecret");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_IdentityResourceClaim_IdentityServer_Identit~",
                table: "IdentityServer_IdentityResourceClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_IdentityResourceProperty_IdentityServer_Iden~",
                table: "IdentityServer_IdentityResourceProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_IdentityResourceProperty",
                table: "IdentityServer_IdentityResourceProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_IdentityResourceClaim",
                table: "IdentityServer_IdentityResourceClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_IdentityResource",
                table: "IdentityServer_IdentityResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_IdentityProvider",
                table: "IdentityServer_IdentityProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientSecret",
                table: "IdentityServer_ClientSecret");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientRedirectUri",
                table: "IdentityServer_ClientRedirectUri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientProperty",
                table: "IdentityServer_ClientProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientPostLogoutRedirectUri",
                table: "IdentityServer_ClientPostLogoutRedirectUri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientIdPRestriction",
                table: "IdentityServer_ClientIdPRestriction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientGrantType",
                table: "IdentityServer_ClientGrantType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientCorsOrigin",
                table: "IdentityServer_ClientCorsOrigin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientClaim",
                table: "IdentityServer_ClientClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_Client",
                table: "IdentityServer_Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiScopeProperty",
                table: "IdentityServer_ApiScopeProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiScopeClaim",
                table: "IdentityServer_ApiScopeClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiScope",
                table: "IdentityServer_ApiScope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResourceSecret",
                table: "IdentityServer_ApiResourceSecret");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResourceScope",
                table: "IdentityServer_ApiResourceScope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResourceProperty",
                table: "IdentityServer_ApiResourceProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResourceClaim",
                table: "IdentityServer_ApiResourceClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResource",
                table: "IdentityServer_ApiResource");

            migrationBuilder.RenameTable(
                name: "IdentityServer_IdentityResourceProperty",
                newName: "IdentityServer_IdentityResourceProperties");

            migrationBuilder.RenameTable(
                name: "IdentityServer_IdentityResourceClaim",
                newName: "IdentityServer_IdentityResourceClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServer_IdentityResource",
                newName: "IdentityServer_IdentityResources");

            migrationBuilder.RenameTable(
                name: "IdentityServer_IdentityProvider",
                newName: "IdentityServer_IdentityProviders");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientSecret",
                newName: "IdentityServer_ClientSecrets");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientRedirectUri",
                newName: "IdentityServer_ClientRedirectUris");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientProperty",
                newName: "IdentityServer_ClientProperties");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientPostLogoutRedirectUri",
                newName: "IdentityServer_ClientPostLogoutRedirectUris");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientIdPRestriction",
                newName: "IdentityServer_ClientIdPRestrictions");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientGrantType",
                newName: "IdentityServer_ClientGrantTypes");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientCorsOrigin",
                newName: "IdentityServer_ClientCorsOrigins");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientClaim",
                newName: "IdentityServer_ClientClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServer_Client",
                newName: "IdentityServer_Clients");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiScopeProperty",
                newName: "IdentityServer_ApiScopeProperties");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiScopeClaim",
                newName: "IdentityServer_ApiScopeClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiScope",
                newName: "IdentityServer_ApiScopes");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResourceSecret",
                newName: "IdentityServer_ApiResourceSecrets");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResourceScope",
                newName: "IdentityServer_ApiResourceScopes");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResourceProperty",
                newName: "IdentityServer_ApiResourceProperties");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResourceClaim",
                newName: "IdentityServer_ApiResourceClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResource",
                newName: "IdentityServer_ApiResources");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_IdentityResourceProperty_IdentityResourceId_~",
                table: "IdentityServer_IdentityResourceProperties",
                newName: "IX_IdentityServer_IdentityResourceProperties_IdentityResourceI~");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_IdentityResourceClaim_IdentityResourceId_Type",
                table: "IdentityServer_IdentityResourceClaims",
                newName: "IX_IdentityServer_IdentityResourceClaims_IdentityResourceId_Ty~");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_IdentityResource_Name",
                table: "IdentityServer_IdentityResources",
                newName: "IX_IdentityServer_IdentityResources_Name");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_IdentityProvider_Scheme",
                table: "IdentityServer_IdentityProviders",
                newName: "IX_IdentityServer_IdentityProviders_Scheme");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientSecret_ClientId",
                table: "IdentityServer_ClientSecrets",
                newName: "IX_IdentityServer_ClientSecrets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientRedirectUri_ClientId_RedirectUri",
                table: "IdentityServer_ClientRedirectUris",
                newName: "IX_IdentityServer_ClientRedirectUris_ClientId_RedirectUri");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientProperty_ClientId_Key",
                table: "IdentityServer_ClientProperties",
                newName: "IX_IdentityServer_ClientProperties_ClientId_Key");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientPostLogoutRedirectUri_ClientId_PostLog~",
                table: "IdentityServer_ClientPostLogoutRedirectUris",
                newName: "IX_IdentityServer_ClientPostLogoutRedirectUris_ClientId_PostLo~");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientIdPRestriction_ClientId_Provider",
                table: "IdentityServer_ClientIdPRestrictions",
                newName: "IX_IdentityServer_ClientIdPRestrictions_ClientId_Provider");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientGrantType_ClientId_GrantType",
                table: "IdentityServer_ClientGrantTypes",
                newName: "IX_IdentityServer_ClientGrantTypes_ClientId_GrantType");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientCorsOrigin_ClientId_Origin",
                table: "IdentityServer_ClientCorsOrigins",
                newName: "IX_IdentityServer_ClientCorsOrigins_ClientId_Origin");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientClaim_ClientId_Type_Value",
                table: "IdentityServer_ClientClaims",
                newName: "IX_IdentityServer_ClientClaims_ClientId_Type_Value");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_Client_ClientId",
                table: "IdentityServer_Clients",
                newName: "IX_IdentityServer_Clients_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiScopeProperty_ScopeId_Key",
                table: "IdentityServer_ApiScopeProperties",
                newName: "IX_IdentityServer_ApiScopeProperties_ScopeId_Key");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiScopeClaim_ScopeId_Type",
                table: "IdentityServer_ApiScopeClaims",
                newName: "IX_IdentityServer_ApiScopeClaims_ScopeId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiScope_Name",
                table: "IdentityServer_ApiScopes",
                newName: "IX_IdentityServer_ApiScopes_Name");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResourceSecret_ApiResourceId",
                table: "IdentityServer_ApiResourceSecrets",
                newName: "IX_IdentityServer_ApiResourceSecrets_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResourceScope_ApiResourceId_Scope",
                table: "IdentityServer_ApiResourceScopes",
                newName: "IX_IdentityServer_ApiResourceScopes_ApiResourceId_Scope");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResourceProperty_ApiResourceId_Key",
                table: "IdentityServer_ApiResourceProperties",
                newName: "IX_IdentityServer_ApiResourceProperties_ApiResourceId_Key");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResourceClaim_ApiResourceId_Type",
                table: "IdentityServer_ApiResourceClaims",
                newName: "IX_IdentityServer_ApiResourceClaims_ApiResourceId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResource_Name",
                table: "IdentityServer_ApiResources",
                newName: "IX_IdentityServer_ApiResources_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_IdentityResourceProperties",
                table: "IdentityServer_IdentityResourceProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_IdentityResourceClaims",
                table: "IdentityServer_IdentityResourceClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_IdentityResources",
                table: "IdentityServer_IdentityResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_IdentityProviders",
                table: "IdentityServer_IdentityProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientSecrets",
                table: "IdentityServer_ClientSecrets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientRedirectUris",
                table: "IdentityServer_ClientRedirectUris",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientProperties",
                table: "IdentityServer_ClientProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientPostLogoutRedirectUris",
                table: "IdentityServer_ClientPostLogoutRedirectUris",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientIdPRestrictions",
                table: "IdentityServer_ClientIdPRestrictions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientGrantTypes",
                table: "IdentityServer_ClientGrantTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientCorsOrigins",
                table: "IdentityServer_ClientCorsOrigins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientClaims",
                table: "IdentityServer_ClientClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_Clients",
                table: "IdentityServer_Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiScopeProperties",
                table: "IdentityServer_ApiScopeProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiScopeClaims",
                table: "IdentityServer_ApiScopeClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiScopes",
                table: "IdentityServer_ApiScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResourceSecrets",
                table: "IdentityServer_ApiResourceSecrets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResourceScopes",
                table: "IdentityServer_ApiResourceScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResourceProperties",
                table: "IdentityServer_ApiResourceProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResourceClaims",
                table: "IdentityServer_ApiResourceClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResources",
                table: "IdentityServer_ApiResources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiResourceClaims_IdentityServer_ApiResource~",
                table: "IdentityServer_ApiResourceClaims",
                column: "ApiResourceId",
                principalTable: "IdentityServer_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiResourceProperties_IdentityServer_ApiReso~",
                table: "IdentityServer_ApiResourceProperties",
                column: "ApiResourceId",
                principalTable: "IdentityServer_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiResourceScopes_IdentityServer_ApiResource~",
                table: "IdentityServer_ApiResourceScopes",
                column: "ApiResourceId",
                principalTable: "IdentityServer_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiResourceSecrets_IdentityServer_ApiResourc~",
                table: "IdentityServer_ApiResourceSecrets",
                column: "ApiResourceId",
                principalTable: "IdentityServer_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiScopeClaims_IdentityServer_ApiScopes_Scop~",
                table: "IdentityServer_ApiScopeClaims",
                column: "ScopeId",
                principalTable: "IdentityServer_ApiScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiScopeProperties_IdentityServer_ApiScopes_~",
                table: "IdentityServer_ApiScopeProperties",
                column: "ScopeId",
                principalTable: "IdentityServer_ApiScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientClaims_IdentityServer_Clients_ClientId",
                table: "IdentityServer_ClientClaims",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientCorsOrigins_IdentityServer_Clients_Cli~",
                table: "IdentityServer_ClientCorsOrigins",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientGrantTypes_IdentityServer_Clients_Clie~",
                table: "IdentityServer_ClientGrantTypes",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientIdPRestrictions_IdentityServer_Clients~",
                table: "IdentityServer_ClientIdPRestrictions",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientPostLogoutRedirectUris_IdentityServer_~",
                table: "IdentityServer_ClientPostLogoutRedirectUris",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientProperties_IdentityServer_Clients_Clie~",
                table: "IdentityServer_ClientProperties",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientRedirectUris_IdentityServer_Clients_Cl~",
                table: "IdentityServer_ClientRedirectUris",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientScopes_IdentityServer_Clients_ClientId",
                table: "IdentityServer_ClientScopes",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientSecrets_IdentityServer_Clients_ClientId",
                table: "IdentityServer_ClientSecrets",
                column: "ClientId",
                principalTable: "IdentityServer_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_IdentityResourceClaims_IdentityServer_Identi~",
                table: "IdentityServer_IdentityResourceClaims",
                column: "IdentityResourceId",
                principalTable: "IdentityServer_IdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_IdentityResourceProperties_IdentityServer_Id~",
                table: "IdentityServer_IdentityResourceProperties",
                column: "IdentityResourceId",
                principalTable: "IdentityServer_IdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiResourceClaims_IdentityServer_ApiResource~",
                table: "IdentityServer_ApiResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiResourceProperties_IdentityServer_ApiReso~",
                table: "IdentityServer_ApiResourceProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiResourceScopes_IdentityServer_ApiResource~",
                table: "IdentityServer_ApiResourceScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiResourceSecrets_IdentityServer_ApiResourc~",
                table: "IdentityServer_ApiResourceSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiScopeClaims_IdentityServer_ApiScopes_Scop~",
                table: "IdentityServer_ApiScopeClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ApiScopeProperties_IdentityServer_ApiScopes_~",
                table: "IdentityServer_ApiScopeProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientClaims_IdentityServer_Clients_ClientId",
                table: "IdentityServer_ClientClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientCorsOrigins_IdentityServer_Clients_Cli~",
                table: "IdentityServer_ClientCorsOrigins");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientGrantTypes_IdentityServer_Clients_Clie~",
                table: "IdentityServer_ClientGrantTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientIdPRestrictions_IdentityServer_Clients~",
                table: "IdentityServer_ClientIdPRestrictions");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientPostLogoutRedirectUris_IdentityServer_~",
                table: "IdentityServer_ClientPostLogoutRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientProperties_IdentityServer_Clients_Clie~",
                table: "IdentityServer_ClientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientRedirectUris_IdentityServer_Clients_Cl~",
                table: "IdentityServer_ClientRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientScopes_IdentityServer_Clients_ClientId",
                table: "IdentityServer_ClientScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_ClientSecrets_IdentityServer_Clients_ClientId",
                table: "IdentityServer_ClientSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_IdentityResourceClaims_IdentityServer_Identi~",
                table: "IdentityServer_IdentityResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServer_IdentityResourceProperties_IdentityServer_Id~",
                table: "IdentityServer_IdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_IdentityResources",
                table: "IdentityServer_IdentityResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_IdentityResourceProperties",
                table: "IdentityServer_IdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_IdentityResourceClaims",
                table: "IdentityServer_IdentityResourceClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_IdentityProviders",
                table: "IdentityServer_IdentityProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientSecrets",
                table: "IdentityServer_ClientSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_Clients",
                table: "IdentityServer_Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientRedirectUris",
                table: "IdentityServer_ClientRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientProperties",
                table: "IdentityServer_ClientProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientPostLogoutRedirectUris",
                table: "IdentityServer_ClientPostLogoutRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientIdPRestrictions",
                table: "IdentityServer_ClientIdPRestrictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientGrantTypes",
                table: "IdentityServer_ClientGrantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientCorsOrigins",
                table: "IdentityServer_ClientCorsOrigins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ClientClaims",
                table: "IdentityServer_ClientClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiScopes",
                table: "IdentityServer_ApiScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiScopeProperties",
                table: "IdentityServer_ApiScopeProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiScopeClaims",
                table: "IdentityServer_ApiScopeClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResourceSecrets",
                table: "IdentityServer_ApiResourceSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResourceScopes",
                table: "IdentityServer_ApiResourceScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResources",
                table: "IdentityServer_ApiResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResourceProperties",
                table: "IdentityServer_ApiResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServer_ApiResourceClaims",
                table: "IdentityServer_ApiResourceClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServer_IdentityResources",
                newName: "IdentityServer_IdentityResource");

            migrationBuilder.RenameTable(
                name: "IdentityServer_IdentityResourceProperties",
                newName: "IdentityServer_IdentityResourceProperty");

            migrationBuilder.RenameTable(
                name: "IdentityServer_IdentityResourceClaims",
                newName: "IdentityServer_IdentityResourceClaim");

            migrationBuilder.RenameTable(
                name: "IdentityServer_IdentityProviders",
                newName: "IdentityServer_IdentityProvider");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientSecrets",
                newName: "IdentityServer_ClientSecret");

            migrationBuilder.RenameTable(
                name: "IdentityServer_Clients",
                newName: "IdentityServer_Client");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientRedirectUris",
                newName: "IdentityServer_ClientRedirectUri");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientProperties",
                newName: "IdentityServer_ClientProperty");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientPostLogoutRedirectUris",
                newName: "IdentityServer_ClientPostLogoutRedirectUri");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientIdPRestrictions",
                newName: "IdentityServer_ClientIdPRestriction");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientGrantTypes",
                newName: "IdentityServer_ClientGrantType");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientCorsOrigins",
                newName: "IdentityServer_ClientCorsOrigin");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ClientClaims",
                newName: "IdentityServer_ClientClaim");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiScopes",
                newName: "IdentityServer_ApiScope");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiScopeProperties",
                newName: "IdentityServer_ApiScopeProperty");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiScopeClaims",
                newName: "IdentityServer_ApiScopeClaim");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResourceSecrets",
                newName: "IdentityServer_ApiResourceSecret");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResourceScopes",
                newName: "IdentityServer_ApiResourceScope");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResources",
                newName: "IdentityServer_ApiResource");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResourceProperties",
                newName: "IdentityServer_ApiResourceProperty");

            migrationBuilder.RenameTable(
                name: "IdentityServer_ApiResourceClaims",
                newName: "IdentityServer_ApiResourceClaim");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_IdentityResources_Name",
                table: "IdentityServer_IdentityResource",
                newName: "IX_IdentityServer_IdentityResource_Name");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_IdentityResourceProperties_IdentityResourceI~",
                table: "IdentityServer_IdentityResourceProperty",
                newName: "IX_IdentityServer_IdentityResourceProperty_IdentityResourceId_~");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_IdentityResourceClaims_IdentityResourceId_Ty~",
                table: "IdentityServer_IdentityResourceClaim",
                newName: "IX_IdentityServer_IdentityResourceClaim_IdentityResourceId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_IdentityProviders_Scheme",
                table: "IdentityServer_IdentityProvider",
                newName: "IX_IdentityServer_IdentityProvider_Scheme");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientSecrets_ClientId",
                table: "IdentityServer_ClientSecret",
                newName: "IX_IdentityServer_ClientSecret_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_Clients_ClientId",
                table: "IdentityServer_Client",
                newName: "IX_IdentityServer_Client_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientRedirectUris_ClientId_RedirectUri",
                table: "IdentityServer_ClientRedirectUri",
                newName: "IX_IdentityServer_ClientRedirectUri_ClientId_RedirectUri");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientProperties_ClientId_Key",
                table: "IdentityServer_ClientProperty",
                newName: "IX_IdentityServer_ClientProperty_ClientId_Key");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientPostLogoutRedirectUris_ClientId_PostLo~",
                table: "IdentityServer_ClientPostLogoutRedirectUri",
                newName: "IX_IdentityServer_ClientPostLogoutRedirectUri_ClientId_PostLog~");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientIdPRestrictions_ClientId_Provider",
                table: "IdentityServer_ClientIdPRestriction",
                newName: "IX_IdentityServer_ClientIdPRestriction_ClientId_Provider");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientGrantTypes_ClientId_GrantType",
                table: "IdentityServer_ClientGrantType",
                newName: "IX_IdentityServer_ClientGrantType_ClientId_GrantType");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientCorsOrigins_ClientId_Origin",
                table: "IdentityServer_ClientCorsOrigin",
                newName: "IX_IdentityServer_ClientCorsOrigin_ClientId_Origin");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ClientClaims_ClientId_Type_Value",
                table: "IdentityServer_ClientClaim",
                newName: "IX_IdentityServer_ClientClaim_ClientId_Type_Value");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiScopes_Name",
                table: "IdentityServer_ApiScope",
                newName: "IX_IdentityServer_ApiScope_Name");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiScopeProperties_ScopeId_Key",
                table: "IdentityServer_ApiScopeProperty",
                newName: "IX_IdentityServer_ApiScopeProperty_ScopeId_Key");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiScopeClaims_ScopeId_Type",
                table: "IdentityServer_ApiScopeClaim",
                newName: "IX_IdentityServer_ApiScopeClaim_ScopeId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResourceSecrets_ApiResourceId",
                table: "IdentityServer_ApiResourceSecret",
                newName: "IX_IdentityServer_ApiResourceSecret_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResourceScopes_ApiResourceId_Scope",
                table: "IdentityServer_ApiResourceScope",
                newName: "IX_IdentityServer_ApiResourceScope_ApiResourceId_Scope");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResources_Name",
                table: "IdentityServer_ApiResource",
                newName: "IX_IdentityServer_ApiResource_Name");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResourceProperties_ApiResourceId_Key",
                table: "IdentityServer_ApiResourceProperty",
                newName: "IX_IdentityServer_ApiResourceProperty_ApiResourceId_Key");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServer_ApiResourceClaims_ApiResourceId_Type",
                table: "IdentityServer_ApiResourceClaim",
                newName: "IX_IdentityServer_ApiResourceClaim_ApiResourceId_Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_IdentityResource",
                table: "IdentityServer_IdentityResource",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_IdentityResourceProperty",
                table: "IdentityServer_IdentityResourceProperty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_IdentityResourceClaim",
                table: "IdentityServer_IdentityResourceClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_IdentityProvider",
                table: "IdentityServer_IdentityProvider",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientSecret",
                table: "IdentityServer_ClientSecret",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_Client",
                table: "IdentityServer_Client",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientRedirectUri",
                table: "IdentityServer_ClientRedirectUri",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientProperty",
                table: "IdentityServer_ClientProperty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientPostLogoutRedirectUri",
                table: "IdentityServer_ClientPostLogoutRedirectUri",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientIdPRestriction",
                table: "IdentityServer_ClientIdPRestriction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientGrantType",
                table: "IdentityServer_ClientGrantType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientCorsOrigin",
                table: "IdentityServer_ClientCorsOrigin",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ClientClaim",
                table: "IdentityServer_ClientClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiScope",
                table: "IdentityServer_ApiScope",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiScopeProperty",
                table: "IdentityServer_ApiScopeProperty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiScopeClaim",
                table: "IdentityServer_ApiScopeClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResourceSecret",
                table: "IdentityServer_ApiResourceSecret",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResourceScope",
                table: "IdentityServer_ApiResourceScope",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResource",
                table: "IdentityServer_ApiResource",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResourceProperty",
                table: "IdentityServer_ApiResourceProperty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServer_ApiResourceClaim",
                table: "IdentityServer_ApiResourceClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiResourceClaim_IdentityServer_ApiResource_~",
                table: "IdentityServer_ApiResourceClaim",
                column: "ApiResourceId",
                principalTable: "IdentityServer_ApiResource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiResourceProperty_IdentityServer_ApiResour~",
                table: "IdentityServer_ApiResourceProperty",
                column: "ApiResourceId",
                principalTable: "IdentityServer_ApiResource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiResourceScope_IdentityServer_ApiResource_~",
                table: "IdentityServer_ApiResourceScope",
                column: "ApiResourceId",
                principalTable: "IdentityServer_ApiResource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiResourceSecret_IdentityServer_ApiResource~",
                table: "IdentityServer_ApiResourceSecret",
                column: "ApiResourceId",
                principalTable: "IdentityServer_ApiResource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiScopeClaim_IdentityServer_ApiScope_ScopeId",
                table: "IdentityServer_ApiScopeClaim",
                column: "ScopeId",
                principalTable: "IdentityServer_ApiScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ApiScopeProperty_IdentityServer_ApiScope_Sco~",
                table: "IdentityServer_ApiScopeProperty",
                column: "ScopeId",
                principalTable: "IdentityServer_ApiScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientClaim_IdentityServer_Client_ClientId",
                table: "IdentityServer_ClientClaim",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientCorsOrigin_IdentityServer_Client_Clien~",
                table: "IdentityServer_ClientCorsOrigin",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientGrantType_IdentityServer_Client_Client~",
                table: "IdentityServer_ClientGrantType",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientIdPRestriction_IdentityServer_Client_C~",
                table: "IdentityServer_ClientIdPRestriction",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientPostLogoutRedirectUri_IdentityServer_C~",
                table: "IdentityServer_ClientPostLogoutRedirectUri",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientProperty_IdentityServer_Client_ClientId",
                table: "IdentityServer_ClientProperty",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientRedirectUri_IdentityServer_Client_Clie~",
                table: "IdentityServer_ClientRedirectUri",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientScopes_IdentityServer_Client_ClientId",
                table: "IdentityServer_ClientScopes",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_ClientSecret_IdentityServer_Client_ClientId",
                table: "IdentityServer_ClientSecret",
                column: "ClientId",
                principalTable: "IdentityServer_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_IdentityResourceClaim_IdentityServer_Identit~",
                table: "IdentityServer_IdentityResourceClaim",
                column: "IdentityResourceId",
                principalTable: "IdentityServer_IdentityResource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServer_IdentityResourceProperty_IdentityServer_Iden~",
                table: "IdentityServer_IdentityResourceProperty",
                column: "IdentityResourceId",
                principalTable: "IdentityServer_IdentityResource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
