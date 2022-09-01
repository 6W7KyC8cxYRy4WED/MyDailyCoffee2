using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDailyCoffee2.Model
{
    public class Customer
    {
        public Customer()
        {
            CustomerPhoneNumbers = new List<CustomerPhoneNumber>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Names { get; set; }

        [Required]
        public string? Lastnames { get; set; }

        public string? Email { get; set; }

        public List<CustomerPhoneNumber>? CustomerPhoneNumbers { get; set; }
    }
}
