using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio_API_GFT.Models
{
    public class Compra
    {
        [Key]
        public int IdCompra {get; set; }
        public Fornecedor Fornecedor {get; set;}
        public int FornecedorId { get; set; }
        public ICollection<ItemCompra> ItensCompras {get; set;} = new List<ItemCompra>();
        
    }
}