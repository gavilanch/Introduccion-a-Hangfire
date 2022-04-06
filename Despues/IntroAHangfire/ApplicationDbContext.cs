using IntroAHangfire.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IntroAHangfire
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas => Set<Persona>();
    }
}
