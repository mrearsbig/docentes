using docentes.Models;
using Microsoft.EntityFrameworkCore;

namespace docentes.Data;

public class DocenteContext : DbContext
{
    public DocenteContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Docente> Docentes { get; set; }
}
