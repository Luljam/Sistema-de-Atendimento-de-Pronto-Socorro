using System;
using System.Collections.Generic;
using System.Text;
using AtendimentoProntoSocorro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoProntoSocorro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Profissional> Profissionals { get; set; }
        public DbSet<DadoClinico> DadosClinicos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Mapeamento um-para-um
            builder.Entity<Ficha>()
                .HasOne(d => d.DadoClinico)
                .WithOne(f => f.Ficha)
                .HasForeignKey<DadoClinico>(d => d.FichaForeignKey);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
