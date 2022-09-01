using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDailyCoffee2.Model
{
    public class CustomerPhoneNumber
    {
        [Key]
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
