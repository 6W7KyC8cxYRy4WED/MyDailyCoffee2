using System.ComponentModel.DataAnnotations;

namespace MyDailyCoffee2.Model
{
    public partial class MaterialMeasurementType : NameKey
    {
        [Required]
        public int DecimalQuantity { get; set; }
    }

    public partial class MaterialMeasurementType
    {
        public static string Decimal => "Decimal";

        public static string Integer => "Integer";

        public static List<MaterialMeasurementType> GetMaterialMeasurementTypes()
        {
            List<MaterialMeasurementType> materialMeasurementTypes = new List<MaterialMeasurementType>();
            materialMeasurementTypes.Add(new MaterialMeasurementType() { Name = Decimal, DecimalQuantity = 2 });
            materialMeasurementTypes.Add(new MaterialMeasurementType() { Name = Integer, DecimalQuantity = 0 });
            return materialMeasurementTypes;
        }
    }
}
