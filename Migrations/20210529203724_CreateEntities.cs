using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_API_GFT.Migrations
{
    public partial class CreateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    IdEstoque = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoEstoque = table.Column<string>(nullable: false),
                    QuantidadeEstoque = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.IdEstoque);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    IdFornecedor = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.IdFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    IdVenda = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.IdVenda);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Unidade = table.Column<string>(nullable: false),
                    EstoqueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produto_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "IdEstoque",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compra_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    VendaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCompra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    CompraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCompra_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "CPF", "Email", "Endereco", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "174.133.260-51", "joao@cliente.com", "Avenida Brasil 160, Centro, Águas de Lindóia, SP, cep 13940-970", "Joao", "11 99887766" },
                    { 2, "168.635.238-76", "maria@cliente.com", "Avenida Independência 160, Centro, Jacarei, SP, cep 15660-970", "Maria", "11 99557766" }
                });

            migrationBuilder.InsertData(
                table: "Estoque",
                columns: new[] { "IdEstoque", "ProdutoEstoque", "QuantidadeEstoque" },
                values: new object[,]
                {
                    { 1, "Dolly Guaraná", 100 },
                    { 2, "Fanta", 150 }
                });

            migrationBuilder.InsertData(
                table: "Fornecedor",
                columns: new[] { "IdFornecedor", "CNPJ", "Email", "Endereco", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "11.815.158/0001-36", "fornecedor@dolly.com", "Avenida Paulista, 2000, Centro, São Paulo, SP, cep 02764-010", "Dolly", "11-9988-7766" },
                    { 2, "14.878.074/0001-30", "fornecedor@ambev.com", "Beco do Miro, 2000, Mangueira, Rio de Janeiro, RJ, cep 20911-138", "Ambev", "11-9668-7766" }
                });

            migrationBuilder.InsertData(
                table: "Compra",
                columns: new[] { "IdCompra", "FornecedorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "IdProduto", "Descricao", "EstoqueId", "Unidade" },
                values: new object[,]
                {
                    { 1, "DollyGuaraná", 1, "UN" },
                    { 2, "Fanta", 2, "UN" },
                    { 3, "FantaUva", 2, "UN" }
                });

            migrationBuilder.InsertData(
                table: "Venda",
                columns: new[] { "IdVenda", "ClienteId", "Status" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "ItemCompra",
                columns: new[] { "Id", "CompraId", "Produto", "Quantidade", "Valor" },
                values: new object[,]
                {
                    { 1, 1, "Fanta", 150, 6.5f },
                    { 2, 1, "FantaUva", 50, 6f },
                    { 3, 2, "DollyGuaraná", 100, 5.5f }
                });

            migrationBuilder.InsertData(
                table: "ItemVenda",
                columns: new[] { "Id", "Produto", "Quantidade", "Valor", "VendaId" },
                values: new object[,]
                {
                    { 1, "Fanta", 10, 10f, 1 },
                    { 2, "FantaUva", 10, 10f, 1 },
                    { 3, "DollyGuaraná", 10, 8f, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_FornecedorId",
                table: "Compra",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_CompraId",
                table: "ItemCompra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_VendaId",
                table: "ItemVenda",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCompra");

            migrationBuilder.DropTable(
                name: "ItemVenda");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
