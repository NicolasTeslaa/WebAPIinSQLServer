using Microsoft.EntityFrameworkCore;
using WebAPIinSQLServer.Entities;

namespace WebAPIinSQLServer.Context
{
    public class ContextWeb : DbContext
    {
        public ContextWeb(DbContextOptions<ContextWeb> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}