using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDailyCoffee2.Migrations
{
    public partial class _00003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    LowerCaseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.LowerCaseName);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortNumber = table.Column<int>(type: "int", nullable: false),
                    MaterialLineName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaterialTypeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaterialBrandName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialMeasurementName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlertThreshold = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    CurrentStock = table.Column<decimal>(type: "decimal(18,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialBrands_MaterialBrandName",
                        column: x => x.MaterialBrandName,
                        principalTable: "MaterialBrands",
                        principalColumn: "LowerCaseName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialLines_MaterialLineName",
                        column: x => x.MaterialLineName,
                        principalTable: "MaterialLines",
                        principalColumn: "LowerCaseName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialMeasurements_MaterialMeasurementName",
                        column: x => x.MaterialMeasurementName,
                        principalTable: "MaterialMeasurements",
                        principalColumn: "LowerCaseName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeName",
                        column: x => x.MaterialTypeName,
                        principalTable: "MaterialTypes",
                        principalColumn: "LowerCaseName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialBrandName",
                table: "Materials",
                column: "MaterialBrandName");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialLineName",
                table: "Materials",
                column: "MaterialLineName");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialMeasurementName",
                table: "Materials",
                column: "MaterialMeasurementName");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeName",
                table: "Materials",
                column: "MaterialTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "MaterialTypes");
        }
    }
}
