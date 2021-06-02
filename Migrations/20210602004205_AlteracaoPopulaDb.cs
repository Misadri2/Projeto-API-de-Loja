using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_API_GFT.Migrations
{
    public partial class AlteracaoPopulaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f0ab9a-8325-42f2-b906-e53a2908f5bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af78c515-f297-4fac-ae1b-dabe7e30db28");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73948ff5-ca31-4643-a702-f204073d5c91", "35a5470f-1c1f-41f5-b83d-0110a297fd1f", "Loja", "LOJA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3acfe5d-9097-45c8-94fe-832b75eb12b3", "5f65cdd9-5a65-4e7b-ac32-ab63a019a63e", "Cliente", "CLIENTE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "af78c515-f297-4fac-ae1b-dabe7e30db28", "1b7138ae-f4a8-46bf-b425-671a0800f9b2", "Loja", "LOJA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98f0ab9a-8325-42f2-b906-e53a2908f5bf", "3428a469-7150-4ef2-bffe-dd59072a7a3e", "Cliente", "CLIENTE" });
        }
    }
}
