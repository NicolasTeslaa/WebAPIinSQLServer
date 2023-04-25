using Microsoft.EntityFrameworkCore;
using WebAPIinSQLServer.Entities;

namespace WebAPIinSQLServer.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}