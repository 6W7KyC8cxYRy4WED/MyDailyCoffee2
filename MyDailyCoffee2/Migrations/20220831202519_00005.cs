using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDailyCoffee2.Migrations
{
    public partial class _00005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CustomerPhoneNumbers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers",
                columns: new[] { "CustomerId", "PhoneNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CustomerPhoneNumbers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers",
                column: "CustomerId");
        }
    }
}
