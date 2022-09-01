using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDailyCoffee2.Migrations
{
    public partial class _00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumber_Customers_CustomerId",
                table: "CustomerPhoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPhoneNumber",
                table: "CustomerPhoneNumber");

            migrationBuilder.RenameTable(
                name: "CustomerPhoneNumber",
                newName: "CustomerPhoneNumbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                table: "CustomerPhoneNumbers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers");

            migrationBuilder.RenameTable(
                name: "CustomerPhoneNumbers",
                newName: "CustomerPhoneNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPhoneNumber",
                table: "CustomerPhoneNumber",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumber_Customers_CustomerId",
                table: "CustomerPhoneNumber",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
