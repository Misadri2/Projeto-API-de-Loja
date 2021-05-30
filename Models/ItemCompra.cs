using System.ComponentModel.DataAnnotations;

namespace Desafio_API_GFT.Models
{
    public class ItemCompra
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Produto { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public float Valor { get; set; }
        public Compra Compra { get; set; }
        public int CompraId { get; set; }
    }
}