using Microsoft.AspNetCore.Components.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MyDailyCoffee2.Model
{
    public class AzureUser
    {
        [Key]
        public string Id { get; set; }
    }
}
