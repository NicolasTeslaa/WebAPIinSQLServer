using Microsoft.AspNetCore.Mvc;
using WebAPIinSQLServer.Context;
using WebAPIinSQLServer.Entities;
using WebAPIinSQLServer.Entities.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ContextWeb _context;
        public UsuarioController(ContextWeb context)
        {
            _context = context;
        }
        [HttpGet("GetAllUsuarios")]
        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var novoUsuario = new Usuario
            {
                Id = Guid.NewGuid().ToString(),
                NomeCompleto = usuario.NomeCompleto,
            };
            _context.Usuarios.Add(novoUsuario);

           await _context.SaveChangesAsync();

            return Ok();
        }
    }
}