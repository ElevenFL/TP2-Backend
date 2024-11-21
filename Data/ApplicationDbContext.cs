using ArticulosAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ArticulosAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbSet<Articulos> articulos) : base(options)
        {
            Articulos = articulos;
        }
        public DbSet<Articulos> Articulos { get; set; }
    }
}
