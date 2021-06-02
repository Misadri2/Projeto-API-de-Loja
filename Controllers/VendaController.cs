using System.Collections.Generic;
using System.Linq;
using Desafio_API_GFT.Database;
using Desafio_API_GFT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API_GFT.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class VendaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VendaController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Venda>> GetItensVendas()
        {
            return _context.Venda.Include(x => x.ItensVendas).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Venda> Get(int id)
        {
            var venda = _context.Venda.FirstOrDefault(p => p.IdVenda == id);

            if (venda == null)
            {
                return NotFound();
            }
            return venda;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Venda venda)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Venda.Add(venda);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Venda venda)
        {

            if (id != venda.IdVenda)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
    }
}