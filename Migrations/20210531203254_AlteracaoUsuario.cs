using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_API_GFT.Migrations
{
    public partial class AlteracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a1e393d-a01d-4231-be5b-95952551233e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea65a702-e3dd-4c68-80ce-8179fb004d6b");

            migrationBuilder.AddColumn<int>(
                name: "TypeUser",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af78c515-f297-4fac-ae1b-dabe7e30db28", "1b7138ae-f4a8-46bf-b425-671a0800f9b2", "Loja", "LOJA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98f0ab9a-8325-42f2-b906-e53a2908f5bf", "3428a469-7150-4ef2-bffe-dd59072a7a3e", "Cliente", "CLIENTE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f0ab9a-8325-42f2-b906-e53a2908f5bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af78c515-f297-4fac-ae1b-dabe7e30db28");

            migrationBuilder.DropColumn(
                name: "TypeUser",
                table: "Usuario");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea65a702-e3dd-4c68-80ce-8179fb004d6b", "de72acc7-3e7f-488f-a09b-e88e031ee545", "Loja", "LOJA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a1e393d-a01d-4231-be5b-95952551233e", "8fe04c1b-9d90-46ec-9215-360e7be7f64b", "Cliente", "CLIENTE" });
        }
    }
}
