using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_API_GFT.Migrations
{
    public partial class AlterarEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantidade",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ItemCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantidade",
                value: 75);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantidade",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ItemCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantidade",
                value: 50);
        }
    }
}
