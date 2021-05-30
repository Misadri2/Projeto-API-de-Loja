using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Desafio_API_GFT.Validacao;

namespace Desafio_API_GFT.Models
{
    public class Fornecedor
    {
        [Key]
        public int IdFornecedor { get; set; }
        
        [ValidaCNPJAttribute]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereco { get; set; } 
        public ICollection<Compra> Compras {get; set;} = new List<Compra>();
    }
}