using System.ComponentModel.DataAnnotations;

namespace Desafio_API_GFT.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Unidade { get; set; }
        public Estoque Estoque { get; set; }
        public int EstoqueId { get; set; }


    }
}