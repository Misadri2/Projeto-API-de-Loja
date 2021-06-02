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
    /* [Authorize(AuthenticationSchemes = "Bearer")] */
    public class CompraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Compra>> Get()
        {
            return _context.Compra.Include(x => x.ItensCompras).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Compra> Get(int id)
        {
            var compra = _context.Compra.FirstOrDefault(p => p.IdCompra == id);

            if (compra == null)
            {
                return NotFound();
            }
            return compra;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Compra compra)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Compra.Add(compra);
            _context.SaveChanges();

            return Ok();
        }       
    }
}