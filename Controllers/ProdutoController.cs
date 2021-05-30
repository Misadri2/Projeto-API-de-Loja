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
    public class ProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get(){    
           return _context.Produto.ToList();
        }

         // api/produtos/1
        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
           
            var produto = _context.Produto.FirstOrDefault(p => p.IdProduto == id);

            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }
        //  api/produtos
        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Produto.Add(produto);
            _context.SaveChanges();

            return Ok();
        }
         
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
           
            if (id != produto.IdProduto)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
           
            var produto = _context.Produto.FirstOrDefault(p => p.IdProduto == id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            _context.SaveChanges();
            return produto;
        }        
    }
}