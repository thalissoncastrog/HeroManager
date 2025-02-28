using HeroManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroManagerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
        public DbSet<HeroSuperPower> HeroesSuperPowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set up many-to-many relationship
            modelBuilder.Entity<HeroSuperPower>().HasKey(hsp => new { hsp.HeroId, hsp.SuperPowerId });

            modelBuilder.Entity<SuperPower>().HasData(
                SuperPower.CreateInitialOptions()
            );

            modelBuilder.Entity<HeroSuperPower>()
                .HasOne(hsp => hsp.Hero)
                .WithMany(h => h.HeroSuperPowers)
                .HasForeignKey(hsp => hsp.HeroId);

            modelBuilder.Entity<HeroSuperPower>()
                .HasOne(hsp => hsp.SuperPower)
                .WithMany(sp => sp.HeroSuperPowers)
                .HasForeignKey(hsp => hsp.SuperPowerId);

            // Inserting some superpowers
            // modelBuilder.Entity<SuperPower>().HasData(
            //     new SuperPower { Id = 1, Superpower = "Super Força", Description = "Capacidade de exercer força sobre-humana." },
            //     new SuperPower { Id = 2, Superpower = "Voo", Description = "Capacidade de voar livremente pelo ar." },
            //     new SuperPower { Id = 3, Superpower = "Invulnerabilidade", Description = "Resistência extrema a danos físicos." },
            //     new SuperPower { Id = 4, Superpower = "Super Velocidade", Description = "Capacidade de se mover em alta velocidade." },
            //     new SuperPower { Id = 5, Superpower = "Telepatia", Description = "Habilidade de ler e influenciar mentes." },
            //     new SuperPower { Id = 6, Superpower = "Telecinese", Description = "Capacidade de mover objetos com a mente." },
            //     new SuperPower { Id = 7, Superpower = "Regeneração", Description = "Habilidade de curar ferimentos rapidamente." },
            //     new SuperPower { Id = 8, Superpower = "Invisibilidade", Description = "Capacidade de ficar invisível à vontade." },
            //     new SuperPower { Id = 9, Superpower = "Manipulação do Tempo", Description = "Habilidade de desacelerar ou acelerar o tempo." },
            //     new SuperPower { Id = 10,Superpower = "Criocinese", Description = "Capacidade de controlar o gelo e a neve." }
            // );
        }
    }
}
