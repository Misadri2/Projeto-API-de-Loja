using System.Collections.Generic;
using System.Linq;
using Desafio_API_GFT.Database;
using Desafio_API_GFT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API_GFT.Controllers
{

    [Route("api/v1/[controller]")]  //https://localhost:5001/swagger/index.html
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    /* [Authorize(Roles = "Cliente")] */

    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return _context.Cliente.ToList();
        }



        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(p => p.IdCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            //validação//
            if (cliente.Nome.Length <= 1)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Nome precisa ter mais de 1 caracter" });
            }
            Cliente c = new Cliente();
            c.Nome = cliente.Nome;
            c.CPF = cliente.CPF;
            c.Telefone = cliente.Telefone;
            c.Email = cliente.Email;
            c.Endereco = cliente.Endereco;
            _context.Cliente.Add(c);
            _context.SaveChanges();
            return Ok(new { msg = "Você cadastrou um novo cliente" });
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<Cliente> Delete(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(p => p.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
            return cliente;
        }
        
    }
}