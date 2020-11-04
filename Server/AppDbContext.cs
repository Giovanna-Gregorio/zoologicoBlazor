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
                .HasOne(ca => ca.Cuidador)
                .WithMany(c => c.CuidadorAnimais)
                .HasForeignKey(ca => ca.IdCuidador);
            
            modelBuilder.Entity<CuidadorAnimal>()
                .HasOne(ca => ca.Animal)
                .WithMany(a => a.CuidadorAnimais)
                .HasForeignKey(ca => ca.IdAnimal);                
        } 
    }
}