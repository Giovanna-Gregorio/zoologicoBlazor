using Microsoft.EntityFrameworkCore;
using zoologicoBlazor.Shared;

namespace zoologicoBlazor.Server
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
        public DbSet<CuidadorAnimal> CuidadorAnimais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuidadorAnimal>()
                .HasKey(c => new {c.IdCuidador, c.IdAnimal}); //chave composta

            modelBuilder.Entity<CuidadorAnimal>()
                .HasOne(c => c.Cuidador)
                .WithMany(ca => ca.CuidadorAnimais)
                .HasForeignKey(c => c.IdCuidador);
            
            modelBuilder.Entity<CuidadorAnimal>()
                .HasOne(a => a.Animal)
                .WithMany(ca => ca.CuidadorAnimais)
                .HasForeignKey(a => a.IdAnimal);                
        }
        
    }
}