using System.Collections.Generic;
using System.Linq;
using Desafio_API_GFT.Database;
using Desafio_API_GFT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API_GFT.Controllers
{
   [Route("api/v1/[controller]")]        
    [ApiController]     
    public class EstoqueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EstoqueController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Estoque>> Get()
        {
            return _context.Estoque.Include(x => x.Produtos).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Estoque> Get(int id)
        {
            var estoque = _context.Estoque.FirstOrDefault(p => p.IdEstoque == id);

            if (estoque == null)
            {
                return NotFound();
            }
            return estoque;
        }

     }
}