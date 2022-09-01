using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDailyCoffee2.Migrations
{
    public partial class _00001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lastnames",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CustomerPhoneNumber",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhoneNumber", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerPhoneNumber_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPhoneNumber");

            migrationBuilder.DropColumn(
                name: "Lastnames",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "Customers");
        }
    }
}
