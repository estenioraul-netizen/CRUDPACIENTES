
using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain.Entities;
using System.Reflection.Emit;

namespace SistemaPacientes.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Hospitalizacion> Hospitalizaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.Cedula)
                .IsUnique();

            modelBuilder.Entity<Medico>()
                .HasOne(m => m.Especialidad)
                .WithMany(e => e.Medicos)
                .HasForeignKey(m => m.EspecialidadId);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Consultas)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Diagnostico>()
                .HasOne(d => d.Consulta)
                .WithMany(c => c.Diagnosticos)
                .HasForeignKey(d => d.ConsultaId);

            modelBuilder.Entity<Receta>()
                .HasOne(r => r.Consulta)
                .WithMany(c => c.Recetas)
                .HasForeignKey(r => r.ConsultaId);

            modelBuilder.Entity<Receta>()
                .HasOne(r => r.Medicamento)
                .WithMany(m => m.Recetas)
                .HasForeignKey(r => r.MedicamentoId);

            modelBuilder.Entity<Hospitalizacion>()
                .HasOne(h => h.Paciente)
                .WithMany(p => p.Hospitalizaciones)
                .HasForeignKey(h => h.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hospitalizacion>()
                .HasOne(h => h.Habitacion)
                .WithMany(h => h.Hospitalizaciones)
                .HasForeignKey(h => h.HabitacionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
