using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDailyCoffee2.Model
{
    public class NameKey
    {
        [Key]
        public string LowerCaseName { get; set; }

        [Required]
        public string Name { get; set; }

        [NotMapped]
        public string DisplayName { get { return Name; } set { Name = value; LowerCaseName = value.ToLower(); } }
    }
}
