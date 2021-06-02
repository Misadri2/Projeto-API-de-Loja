using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_API_GFT.Migrations
{
    public partial class AlteracaoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73948ff5-ca31-4643-a702-f204073d5c91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3acfe5d-9097-45c8-94fe-832b75eb12b3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a5aee85-ddf8-4f3c-8fa3-a0781da533bc", "3f208c5c-412c-49c9-8563-38171f63be4a", "Loja", "LOJA" },
                    { "7a290fdf-ee19-43e4-8e44-4af7de2cfddf", "4b41f5d7-f7dc-4d7b-957c-ba809f082093", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Senha", "TypeUser" },
                values: new object[,]
                {
                    { 1, "Loja@loja.com", "GFT2021", 0 },
                    { 2, "Cliente@cliente.com", "GFT2021", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a5aee85-ddf8-4f3c-8fa3-a0781da533bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a290fdf-ee19-43e4-8e44-4af7de2cfddf");

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73948ff5-ca31-4643-a702-f204073d5c91", "35a5470f-1c1f-41f5-b83d-0110a297fd1f", "Loja", "LOJA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3acfe5d-9097-45c8-94fe-832b75eb12b3", "5f65cdd9-5a65-4e7b-ac32-ab63a019a63e", "Cliente", "CLIENTE" });
        }
    }
}
