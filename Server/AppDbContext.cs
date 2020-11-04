using Microsoft.EntityFrameworkCore;
using zoologicoBlazor.Shared;

namespace Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Cuidador> Cuidadores { get; set; }
        public DbSet<CuidadorDetails> CuidadorDetails { get; set; }

        //public DbSet<CuidadorAnimal> CuidadorAnimais {get; set; }
        
    }
}