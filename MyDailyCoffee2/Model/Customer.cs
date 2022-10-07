using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDailyCoffee2.Model
{
    public class Customer
    {
        public Customer()
        {
            CustomerPhoneNumbers = new List<CustomerPhoneNumber>();
            Deleted = false;
            CreatedAt = DateTimeOffset.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Names { get; set; }

        [Required]
        public string? Lastnames { get; set; }

        public string? Email { get; set; }

        public List<CustomerPhoneNumber>? CustomerPhoneNumbers { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public string CreatedById { get; set; }

        public AzureUser CreatedBy { get; set; }

        [Required]
        public DateTimeOffset UpdatedAt { get; set; }

        [ForeignKey("UpdatedBy")]
        public string UpdatedById { get; set; }

        public AzureUser UpdatedBy { get; set; }

        public void Delete(AzureUser azureUser)
        {
            Deleted = true;
            SetLastUpdate(azureUser);
        }

        private void SetLastUpdate(AzureUser azureUser)
        {
            UpdatedAt = DateTimeOffset.Now;
            UpdatedById = azureUser.Id;
        }

        public void Update(AzureUser azureUser)
        {
            SetLastUpdate(azureUser);
        }
    }
}
