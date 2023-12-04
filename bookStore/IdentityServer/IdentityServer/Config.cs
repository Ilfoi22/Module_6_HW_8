using IdentityServer4.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }

    public static IEnumerable<ApiResource> GetApis()
    {
        return new ApiResource[]
        {
            new ApiResource("catalog")
            {
                Scopes = new List<Scope>
                {
                    new Scope("catalog.catalogauthor"),
                    new Scope("catalog.catalogbook"),
                    new Scope("catalog.cataloggenre")
                },
            }
        };
    }

    public static IEnumerable<Client> GetClients(IConfiguration configuration)
    {
        return new[]
        {
            new Client
            {
                ClientId = "catalog",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
            },
            new Client
            {
                ClientId = "catalogswaggerui",
                ClientName = "Catalog Swagger UI",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,

                RedirectUris = { $"{configuration["CatalogApi"]}/swagger/oauth2-redirect.html" },
                PostLogoutRedirectUris = { $"{configuration["CatalogApi"]}/swagger/" },
                AllowedScopes =
                {
                    "catalog.catalogauthor", "catalog.catalogbook", "catalog.cataloggenre"
                }
            }
        };
    }
}
