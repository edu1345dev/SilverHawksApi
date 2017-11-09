using System;
using Microsoft.EntityFrameworkCore;
using SilverHawksUserApi.Models;

namespace SilverHawksUserApi.Data
{
    public class SilverHawksContext : DbContext
    {
        public SilverHawksContext(DbContextOptions<SilverHawksContext> options)
            :base(options)
        {
        }

        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<Chamada> Chamadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atleta>().ToTable("Atleta");
            modelBuilder.Entity<Presenca>().ToTable("Presenca");
            modelBuilder.Entity<Chamada>().ToTable("Chamada");
        }
    }
}
