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
        [HttpGet("GetById/{id}")]
        public ActionResult<Usuario> GetById(string id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(c => c.Id == id);
            if (usuario == null)
            {
                return BadRequest(404);
            }
            return usuario;
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
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UsuarioUpdateModel usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarioExistente.NomeCompleto = usuario.NomeCompleto;
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);

            _context.SaveChanges();

            return Ok();
        }


    }
}