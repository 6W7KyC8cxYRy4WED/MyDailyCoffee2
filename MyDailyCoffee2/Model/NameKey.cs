using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDailyCoffee2.Model
{
    public class NameKey
    {
        [Key]
        public string LowerCaseName { get; set; }

        [Required]
        public string Name { get { return name; } set { name = value; LowerCaseName = value.ToLower(); } }

        private string name;
    }
}
