using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Desafio_API_GFT.Models.Enum;

namespace Desafio_API_GFT.Models
{
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }
        public Cliente Cliente {get; set; }       
        public int ClienteId {get; set; }
        public VendaStatus Status {get; set; }
        public ICollection<ItemVenda> ItensVendas {get; set;} = new List<ItemVenda>();
      

    }
}