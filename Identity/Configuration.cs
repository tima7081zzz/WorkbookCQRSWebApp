using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity;

public static class Configuration
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new("WorkBookWebAPI", "Web API")
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new("WorkBookWebAPI", "Web API", new[] {JwtClaimTypes.Name})
            {
                Scopes = {"WorkBookWebAPI"}
            }
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "workbook-web-api",
                ClientName = "WorkBook Web",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    //TODO: add redirects
                    "http://.../signin-oidc"
                },
                AllowedCorsOrigins =
                {
                    //TODO: add cors
                    "http://..."
                },
                PostLogoutRedirectUris =
                {
                    //TODO: add redirects
                    "http:/.../signout-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "WorkBookWebAPI"
                },
                AllowAccessTokensViaBrowser = true,
            }
        };
}