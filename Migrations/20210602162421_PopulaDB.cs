using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_API_GFT.Migrations
{
    public partial class PopulaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a5aee85-ddf8-4f3c-8fa3-a0781da533bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a290fdf-ee19-43e4-8e44-4af7de2cfddf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dddacccc-76a7-4743-b1b7-bc7ffc88f749", "472f5c6d-36ff-41f5-98a1-ae1dce51d6a2", "Loja", "LOJA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9cd639e-d598-4c6e-a15e-1874badb8c94", "69ef17fc-ac37-4bb1-aa45-96f275c77af6", "Cliente", "CLIENTE" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "adm@admin.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dddacccc-76a7-4743-b1b7-bc7ffc88f749");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9cd639e-d598-4c6e-a15e-1874badb8c94");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a5aee85-ddf8-4f3c-8fa3-a0781da533bc", "3f208c5c-412c-49c9-8563-38171f63be4a", "Loja", "LOJA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a290fdf-ee19-43e4-8e44-4af7de2cfddf", "4b41f5d7-f7dc-4d7b-957c-ba809f082093", "Cliente", "CLIENTE" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "Loja@loja.com");
        }
    }
}
