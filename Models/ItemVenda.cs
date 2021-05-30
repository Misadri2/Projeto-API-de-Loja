using System.ComponentModel.DataAnnotations;

namespace Desafio_API_GFT.Models
{
    public class ItemVenda
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Produto { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public float Valor { get; set; }
        public Venda Venda { get; set; }
        public int VendaId { get; set; }

    }
}