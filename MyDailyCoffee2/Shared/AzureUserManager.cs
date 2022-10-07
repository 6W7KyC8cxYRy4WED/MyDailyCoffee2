using Microsoft.AspNetCore.Components.Authorization;
using MyDailyCoffee2.Model;
using System.Security.Claims;

namespace MyDailyCoffee2.Shared
{
    public static class AzureUserManager
    {
        public static AzureUser Get(DatabaseContext databaseContext, AuthenticationStateProvider authenticationStateProvider)
        {
            AuthenticationState authenticationState = authenticationStateProvider.GetAuthenticationStateAsync().Result;
            ClaimsPrincipal claimsPrincipal = authenticationState.User;
            AzureUser azureUser = new AzureUser();
            azureUser.Id = claimsPrincipal.Claims.Single(c => c.Type == "uid").Value;

            if (!databaseContext.AzureUsers.Any(au => au.Id == azureUser.Id))
            {
                databaseContext.Add(azureUser);
                databaseContext.SaveChanges();
            }

            return azureUser;
        }
    }
}
