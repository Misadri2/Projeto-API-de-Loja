using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Desafio_API_GFT.Database;
using Desafio_API_GFT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace Desafio_API_GFT.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {     
        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }          
        
        [HttpGet]
       public ActionResult<IEnumerable<Usuario>> Get()
        {
            return  _context.Usuario.ToList();
        }

        [HttpPost("registro")]
        //api/v1/usuario/registro
        public IActionResult Registro([FromBody] Usuario usuario){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }       
                _context.Add(usuario);
                _context.SaveChanges();
                return Ok(new { msg = "Usuário cadastrado com sucesso" });
           
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Usuario credenciais)
        {           
            try
            {
                Usuario usuario =  _context.Usuario.First(user => user.Email.Equals(credenciais.Email));
                if (usuario != null)
                {
                  
                    if (usuario.Senha.Equals(credenciais.Senha))
                    {
                        //Geração de Token
                        string chaveDeSeguranca = "Gft_melhor_empresa12345";       // Chave de segurança              
                        var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveDeSeguranca));
                        var credenciaisDeAcesso = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);
                    
                        var claims = new List<Claim>();
                        claims.Add(new Claim("id", usuario.Id.ToString()));
                        claims.Add(new Claim("email", usuario.Email.ToString()));
                        claims.Add(new Claim(ClaimTypes.Role, "Loja"));                
                        claims.Add(new Claim(ClaimTypes.Role, "Cliente")); 

                        var IdentityClaims =new ClaimsIdentity();
                        IdentityClaims.AddClaims(claims);               
                        
                        var JWT = new JwtSecurityToken(
                            issuer: "starters.com",  //Quem está fornecendo o JWT para o usuário
                            expires: DateTime.Now.AddHours(1),
                            audience: "usuario_comum",                            
                            signingCredentials: credenciaisDeAcesso,
                            claims: claims   // adicionando claims no token
                        );

                        return Ok(new JwtSecurityTokenHandler().WriteToken(JWT));
                                        
                    }
                    else
                    {
                        Response.StatusCode = 401; // Não autorizado // Não existe nenhum usuário com este e-mail
                        return new ObjectResult("");
                    }
                }
                else
                {
                    // Não existe nenhum usuário com este e-mail
                    Response.StatusCode = 401; // Não autorizado
                    return new ObjectResult("");
                }
            }
            catch (Exception)
            {
                // Não existe nenhum usuário com este e-mail
                Response.StatusCode = 401; // Não autorizado
                return new ObjectResult("");
            }
        }
    }
}
    



