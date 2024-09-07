using docentes.Models;
using Microsoft.EntityFrameworkCore;

namespace docentes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Docente> Docentes { get; set; }
    }
}
