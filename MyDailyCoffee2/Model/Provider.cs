using System.ComponentModel.DataAnnotations;

namespace MyDailyCoffee2.Model
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? LegalName { get; set; }

        public string? LegalId { get; set; }

        public string? Description { get; set; }
    }
}
