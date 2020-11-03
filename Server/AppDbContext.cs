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
    }
}