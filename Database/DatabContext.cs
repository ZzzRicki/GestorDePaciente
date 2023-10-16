using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabContext : DbContext
    {
        public DatabContext(DbContextOptions<DatabContext> options) : base(options) { }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciete { get; set; }
        public DbSet<Prueba> Prueba { get; set; }
        public DbSet<Resultados> Resultado { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>().ToTable("Cita");
        modelBuilder.Entity<Medico>().ToTable("Medico");
        modelBuilder.Entity<Paciente>().ToTable("Paciente");
        modelBuilder.Entity<Prueba>().ToTable("Prueba");
        modelBuilder.Entity<Resultados>().ToTable("Resultado");
        modelBuilder.Entity<Usuario>().ToTable("Usuario");

        modelBuilder.Entity<Cita>().HasKey(x => x.IdCita);
        modelBuilder.Entity<Medico>().HasKey(x => x.IdMedico);
        modelBuilder.Entity<Paciente>().HasKey(x => x.IdPaciente);
        modelBuilder.Entity<Prueba>().HasKey(x => x.IdPrueba);
        modelBuilder.Entity<Resultados>().HasKey(x => x.IdResultado);
        modelBuilder.Entity<Usuario>().HasKey(x => x.IdUsuario);

        modelBuilder.Entity<Cita>()
     .HasOne(c => c.IdMedico)
     .WithMany(m => m.Citas)
     .HasForeignKey(c => c.IdMedico)
     .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Cita>()
            .HasOne(c => c.IdPaciente)
            .WithMany(p => p.Citas)
            .HasForeignKey(c => c.IdPaciente)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Prueba>()
            .HasOne(p => p.Resultados)
            .WithMany(r => r.Pruebas)
            .HasForeignKey(p => p.IdResultado)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Medico)
            .WithOne(m => m.Usuario)
            .HasForeignKey<Medico>(m => m.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Paciente)
            .WithOne(p => p.Usuario)
            .HasForeignKey<Paciente>(p => p.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
