using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio_API_GFT.Models
{
    public class Estoque 
    {
        [Key]        
        public int IdEstoque { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ProdutoEstoque { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int QuantidadeEstoque { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();    
       
    }
}