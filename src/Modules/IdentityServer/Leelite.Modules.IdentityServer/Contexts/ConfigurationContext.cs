using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Skoruba.IdentityServer4.Admin.EntityFramework.Interfaces;

namespace Leelite.Modules.IdentityServer.Contexts
{
    public class ConfigurationContext : ConfigurationDbContext<ConfigurationContext>, IAdminConfigurationDbContext
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options, ConfigurationStoreOptions storeOptions)
            : base(options, storeOptions)
        {
            storeOptions.Client.Name = TableConsts.Clients;
            storeOptions.ClientClaim.Name = TableConsts.ClientClaims;
            storeOptions.ClientScopes.Name = TableConsts.ClientScopes;
            storeOptions.ClientSecret.Name = TableConsts.ClientSecrets;
            storeOptions.ClientProperty.Name = TableConsts.ClientProperties;
            storeOptions.ClientGrantType.Name = TableConsts.ClientGrantTypes;
            storeOptions.ClientCorsOrigin.Name = TableConsts.ClientCorsOrigins;
            storeOptions.ClientRedirectUri.Name = TableConsts.ClientRedirectUris;
            storeOptions.ClientIdPRestriction.Name = TableConsts.ClientIdPRestrictions;
            storeOptions.ClientPostLogoutRedirectUri.Name = TableConsts.ClientPostLogoutRedirectUris;

            storeOptions.ApiClaim.Name = TableConsts.ApiClaims;
            storeOptions.ApiScope.Name = TableConsts.ApiScopes;
            storeOptions.ApiSecret.Name = TableConsts.ApiSecrets;
            storeOptions.ApiResource.Name = TableConsts.ApiResources;
            storeOptions.ApiScopeClaim.Name = TableConsts.ApiScopeClaims;

            storeOptions.IdentityClaim.Name = TableConsts.IdentityClaims;
            storeOptions.IdentityResource.Name = TableConsts.IdentityResources;
        }

        public DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }

        public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }

        public DbSet<ApiSecret> ApiSecrets { get; set; }

        public DbSet<ApiScope> ApiScopes { get; set; }

        public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }

        public DbSet<IdentityClaim> IdentityClaims { get; set; }

        public DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }

        public DbSet<ClientGrantType> ClientGrantTypes { get; set; }

        public DbSet<ClientScope> ClientScopes { get; set; }

        public DbSet<ClientSecret> ClientSecrets { get; set; }

        public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }

        public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }

        public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }

        public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }

        public DbSet<ClientClaim> ClientClaims { get; set; }

        public DbSet<ClientProperty> ClientProperties { get; set; }
    }
}
