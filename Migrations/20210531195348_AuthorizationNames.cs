using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_API_GFT.Migrations
{
    public partial class AuthorizationNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea65a702-e3dd-4c68-80ce-8179fb004d6b", "de72acc7-3e7f-488f-a09b-e88e031ee545", "Loja", "LOJA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a1e393d-a01d-4231-be5b-95952551233e", "8fe04c1b-9d90-46ec-9215-360e7be7f64b", "Cliente", "CLIENTE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a1e393d-a01d-4231-be5b-95952551233e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea65a702-e3dd-4c68-80ce-8179fb004d6b");
        }
    }
}
