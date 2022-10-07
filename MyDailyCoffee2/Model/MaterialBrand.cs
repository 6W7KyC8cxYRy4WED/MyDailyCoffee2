using System.ComponentModel.DataAnnotations;

namespace MyDailyCoffee2.Model
{
    public class MaterialBrand : NameKey
    {
        public string? Description { get; set; }
    }
}
