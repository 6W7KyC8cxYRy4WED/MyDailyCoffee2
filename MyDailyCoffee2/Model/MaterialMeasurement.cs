using System.ComponentModel.DataAnnotations.Schema;

namespace MyDailyCoffee2.Model
{
    public partial class MaterialMeasurement : NameKey
    {
        [ForeignKey("MaterialMeasurementType")]
        public string MaterialMeasurementTypeName { get; set; } = null!;

        public MaterialMeasurementType MaterialMeasurementType { get; set; } = null!;
    }

    public partial class MaterialMeasurement
    {
        public static List<MaterialMeasurement> GetMaterialMeasurements()
        {
            List<MaterialMeasurement> materialMeasurements = new List<MaterialMeasurement>();
            materialMeasurements.Add(new MaterialMeasurement() { Name = "Unidades", MaterialMeasurementTypeName = MaterialMeasurementType.Integer });
            materialMeasurements.Add(new MaterialMeasurement() { Name = "Metros", MaterialMeasurementTypeName = MaterialMeasurementType.Decimal });
            return materialMeasurements;
        }
    }
}
