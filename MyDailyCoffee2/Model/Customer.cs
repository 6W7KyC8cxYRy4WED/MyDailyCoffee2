using MyDailyCoffee2.Shared;
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

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTimeOffset UpdatedAt { get; set; }

        [Required]
        public string? UpdatedBy { get; set; }

        public void Delete(AzureUser azureUser)
        {
            Deleted = true;
            SetLastUpdate(azureUser);
        }

        private void SetLastUpdate(AzureUser azureUser)
        {
            UpdatedAt = DateTimeOffset.Now;
            UpdatedBy = azureUser.GetUID();
        }

        public void Update(AzureUser azureUser)
        {
            SetLastUpdate(azureUser);
        }
    }
}
