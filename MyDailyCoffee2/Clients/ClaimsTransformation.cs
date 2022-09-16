using Microsoft.AspNetCore.Authentication;
using Microsoft.Graph;
using System.Security.Claims;

namespace MyDailyCoffee2.Clients
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        private readonly MicrosoftGraphApplicationService microsoftGraphApplicationService;

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            if (!principal.HasClaim(claim => claim.Type.Equals("group")))
            {
                string objectidentifierClaimType = "http://schemas.microsoft.com/identity/claims/objectidentifier";
                Claim? claim = principal.Claims.FirstOrDefault(t => t.Type == objectidentifierClaimType);
                IDirectoryObjectGetMemberGroupsCollectionPage groupCollection = await microsoftGraphApplicationService.GetGraphUserMemberGroups(claim!.Value);

                foreach(string groupId in groupCollection)
                {
                    Claim groupClaim = GetGroupClaim(groupId);

                    if(groupClaim != null)
                    {
                        claimsIdentity.AddClaim(groupClaim);
                    }
                }
            }

            principal.AddIdentity(claimsIdentity);
            return principal;
        }

        private Claim GetGroupClaim(string groupId)
        {
            Dictionary<string, Claim> mappings = new Dictionary<string, Claim>() 
            {
                { "eebeff29-1a6b-4173-8a11-062d49796f60",
                    new Claim("1","MDC2.Customer.Edit")},
            };

            if (mappings.ContainsKey(groupId))
            {
                return mappings[groupId];
            }

            return null;
        }
    }
}
