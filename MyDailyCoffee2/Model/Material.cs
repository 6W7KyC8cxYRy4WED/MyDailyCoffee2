using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDailyCoffee2.Model
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SortNumber { get; set; }

        public MaterialLine MaterialLine { get; set; }

        [ForeignKey("MaterialLine")]
        public string MaterialLineName { get; set; }

        public MaterialType MaterialType { get; set; }

        [ForeignKey("MaterialType")]
        public string MaterialTypeName { get; set; }

        public MaterialBrand MaterialBrand { get; set; }

        [ForeignKey("MaterialBrand")]
        public string MaterialBrandName { get; set; }

        [Required]
        public string Name { get; set; }

        public string Model { get; set; }

        public string Class { get; set; }

        public MaterialMeasurement MaterialMeasurement { get; set; }

        [Required]
        [ForeignKey("MaterialMeasurement")]
        public string MaterialMeasurementName { get; set; }

        [Column(TypeName = "decimal(18,10)")]
        public decimal? AlertThreshold { get; set; }

        [Column(TypeName = "decimal(18,10)")]
        public decimal CurrentStock { get; set; }
    }
}
