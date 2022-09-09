using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MyDailyCoffee2.Shared
{
    public class AzureUser
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;

        private readonly AuthenticationState authenticationState;

        private readonly ClaimsPrincipal claimsPrincipal;

        public AzureUser(AuthenticationStateProvider authenticationStateProvider)
        {
            this.authenticationStateProvider = authenticationStateProvider;
            authenticationState = authenticationStateProvider.GetAuthenticationStateAsync().Result;
            claimsPrincipal = authenticationState.User;
        }

        public string GetUID()
        {
            return "";
        }
    }
}
