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
        private readonly Context _context;

        public UsuarioController(Context context)
        {
            _context = context;
        }
        [HttpGet("GetAllUsuarios")]
        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios;
        }
        [HttpPost("Create")]
        public IActionResult Create(Usuario usuario)
        {
            _context.Add(usuario);

            _context.SaveChangesAsync();

            return Ok();
        }
    }
}