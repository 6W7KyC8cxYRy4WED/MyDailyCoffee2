using Azure.Identity;
using Microsoft.Graph;

namespace MyDailyCoffee2.Clients
{
    public class MicrosoftGraphApplicationService
    {
        private readonly IConfiguration configuration;

        public MicrosoftGraphApplicationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IUserAppRoleAssignmentsCollectionPage>GetGraphUserAppRoles(string objectIdentifier)
        {
            var graphServiceClient = GetGraphClient();
            return await graphServiceClient.Users[objectIdentifier].AppRoleAssignments.Request().GetAsync();
        }

        public async Task<IDirectoryObjectGetMemberGroupsCollectionPage>GetGraphUserMemberGroups(string objectIdentifier)
        {
            bool securityEnabledOnly = true;
            GraphServiceClient graphServiceClient = GetGraphClient();
            return await graphServiceClient.Users[objectIdentifier].GetMemberGroups(securityEnabledOnly).Request().PostAsync();
        }

        private GraphServiceClient GetGraphClient()
        {
            string[] scopes = new[] { "https://graph.microsoft.com/.default" };
            string tenantId = configuration["AzureAd:TenantId"];
            string clientId = configuration.GetValue<string>("AzureAd:ClientId");
            string clientSecret = configuration.GetValue<string>("AzureAd:ClientSecret");

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);
            return new GraphServiceClient(clientSecretCredential, scopes);
        }
    }
}
