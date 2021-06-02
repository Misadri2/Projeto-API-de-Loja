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

    public class FornecedorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FornecedorController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> Get()
        {
            return _context.Fornecedor.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Fornecedor> Get(int id)
        {
            var fornecedor = _context.Fornecedor.FirstOrDefault(p => p.IdFornecedor == id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            return fornecedor;
        }


        [HttpPost]
        public ActionResult Post([FromBody] Fornecedor fornecedor)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fornecedor.Add(fornecedor);
            _context.SaveChanges();

            return Ok(new { msg = "Você cadastrou um novo fornecedor" });
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Fornecedor fornecedor)
        {

            if (id != fornecedor.IdFornecedor)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<Fornecedor> Delete(int id)
        {

            var fornecedor = _context.Fornecedor.FirstOrDefault(p => p.IdFornecedor == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedor.Remove(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }
    }
}