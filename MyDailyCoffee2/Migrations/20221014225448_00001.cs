using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDailyCoffee2.Migrations
{
    public partial class _00001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialMeasurementTypes",
                columns: table => new
                {
                    LowerCaseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DecimalQuantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialMeasurementTypes", x => x.LowerCaseName);
                });

            migrationBuilder.CreateTable(
                name: "MaterialMeasurements",
                columns: table => new
                {
                    LowerCaseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaterialMeasurementTypeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialMeasurements", x => x.LowerCaseName);
                    table.ForeignKey(
                        name: "FK_MaterialMeasurements_MaterialMeasurementTypes_MaterialMeasurementTypeName",
                        column: x => x.MaterialMeasurementTypeName,
                        principalTable: "MaterialMeasurementTypes",
                        principalColumn: "LowerCaseName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMeasurements_MaterialMeasurementTypeName",
                table: "MaterialMeasurements",
                column: "MaterialMeasurementTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialMeasurements");

            migrationBuilder.DropTable(
                name: "MaterialMeasurementTypes");
        }
    }
}
