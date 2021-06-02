using Desafio_API_GFT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Desafio_API_GFT.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItemCompra> ItemCompra { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        { }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Loja",
                NormalizedName = "Loja".ToUpper()
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Cliente",
                NormalizedName = "Cliente".ToUpper()
            });

            var usuario = new[]{
              new Usuario {Id=1, Email= "Loja@loja.com", Senha="GFT2021", TypeUser=(Models.Enum.PerfilUsuario)0 },
              new Usuario {Id=2, Email= "Cliente@cliente.com", Senha="GFT2021", TypeUser=(Models.Enum.PerfilUsuario)1}
            };

            var fornecedor = new[]{
              new Fornecedor {IdFornecedor=1, CNPJ="11.815.158/0001-36", Nome="Dolly", Telefone="11-9988-7766", Email="fornecedor@dolly.com", Endereco="Avenida Paulista, 2000, Centro, São Paulo, SP, cep 02764-010" },
              new Fornecedor {IdFornecedor=2, CNPJ="14.878.074/0001-30", Nome="Ambev", Telefone="11-9668-7766", Email="fornecedor@ambev.com", Endereco="Beco do Miro, 2000, Mangueira, Rio de Janeiro, RJ, cep 20911-138"},
          };

            var estoque = new[]{
              new Estoque {IdEstoque=1, ProdutoEstoque="Dolly Guaraná", QuantidadeEstoque=100},
              new Estoque {IdEstoque=2, ProdutoEstoque="Fantas", QuantidadeEstoque=150},
          };

            var cliente = new[]{
              new Cliente {IdCliente=1, CPF="174.133.260-51", Nome="Joao", Telefone="11 99887766", Email="joao@cliente.com", Endereco="Avenida Brasil 160, Centro, Águas de Lindóia, SP, cep 13940-970"},
              new Cliente {IdCliente=2, CPF="168.635.238-76", Nome="Maria", Telefone="11 99557766", Email="maria@cliente.com", Endereco="Avenida Independência 160, Centro, Jacarei, SP, cep 15660-970"},
          };

            modelBuilder.Entity<Fornecedor>().HasData(fornecedor[0], fornecedor[1]);
            modelBuilder.Entity<Cliente>().HasData(cliente[0], cliente[1]);
            modelBuilder.Entity<Estoque>().HasData(estoque[0], estoque[1]);
            modelBuilder.Entity<Usuario>().HasData(usuario[0], usuario[1]);


            modelBuilder.Entity<Produto>().HasData(new { IdProduto = 1, Descricao = "DollyGuaraná", Unidade = "UN", EstoqueId = 1 });
            modelBuilder.Entity<Produto>().HasData(new { IdProduto = 2, Descricao = "FantaLaranja", Unidade = "UN", EstoqueId = 2 });
            modelBuilder.Entity<Produto>().HasData(new { IdProduto = 3, Descricao = "FantaUva", Unidade = "UN", EstoqueId = 2 });


            var compra = new[]{
              new Compra { IdCompra=1, FornecedorId=1},
              new Compra { IdCompra=2, FornecedorId=2},
            };

            var venda = new[]{
              new Venda { IdVenda=1, ClienteId=1, Status=(Models.Enum.VendaStatus)0},
              new Venda { IdVenda=2, ClienteId=2, Status=(Models.Enum.VendaStatus)0},
            };

            modelBuilder.Entity<Compra>().HasData(compra[0], compra[1]);
            modelBuilder.Entity<Venda>().HasData(venda[0], venda[1]);

            modelBuilder.Entity<ItemCompra>().HasData(new { Id = 1, Produto = "Fanta", Quantidade = 150, Valor = 6.50f, CompraId = 1 });
            modelBuilder.Entity<ItemCompra>().HasData(new { Id = 2, Produto = "FantaUva", Quantidade = 50, Valor = 6.00f, CompraId = 1 });
            modelBuilder.Entity<ItemCompra>().HasData(new { Id = 3, Produto = "DollyGuaraná", Quantidade = 100, Valor = 5.50f, CompraId = 2 });
            modelBuilder.Entity<ItemVenda>().HasData(new { Id = 1, Produto = "Fanta", Quantidade = 10, Valor = 10.00f, VendaId = 1 });
            modelBuilder.Entity<ItemVenda>().HasData(new { Id = 2, Produto = "FantaUva", Quantidade = 10, Valor = 10.00f, VendaId = 1 });
            modelBuilder.Entity<ItemVenda>().HasData(new { Id = 3, Produto = "DollyGuaraná", Quantidade = 10, Valor = 8.00f, VendaId = 2 });
        }
    }
}