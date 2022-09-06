using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDailyCoffee2.Migrations
{
    public partial class _00006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CustomerPhoneNumbers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerPhoneNumbers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CustomerPhoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumbers_CustomerId",
                table: "CustomerPhoneNumbers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                table: "CustomerPhoneNumbers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPhoneNumbers_CustomerId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomerPhoneNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CustomerPhoneNumbers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerPhoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPhoneNumbers",
                table: "CustomerPhoneNumbers",
                columns: new[] { "CustomerId", "PhoneNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumbers_Customers_CustomerId",
                table: "CustomerPhoneNumbers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
