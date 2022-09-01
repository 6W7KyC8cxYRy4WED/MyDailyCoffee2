using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDailyCoffee2.Migrations
{
    public partial class _00003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "CustomerPhoneNumbers");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CustomerPhoneNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CustomerPhoneNumbers");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "CustomerPhoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
