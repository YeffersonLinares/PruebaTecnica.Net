using Microsoft.EntityFrameworkCore;
using MyDotnetPostgresApi.Models;

namespace MyDotnetPostgresApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<NumeroTelefonico> NumerosTelefonicos { get; set; }
        public DbSet<CorreoElectronico> CorreosElectronicos { get; set; }
        public DbSet<DireccionFisica> DireccionesFisicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar las relaciones de clave foránea
            modelBuilder.Entity<NumeroTelefonico>()
                .HasOne(n => n.Persona)
                .WithMany(p => p.NumerosTelefonicos)
                .HasForeignKey(n => n.PersonaDocumentoIdentidad);

            modelBuilder.Entity<CorreoElectronico>()
                .HasOne(c => c.Persona)
                .WithMany(p => p.CorreosElectronicos)
                .HasForeignKey(c => c.PersonaDocumentoIdentidad);

            modelBuilder.Entity<DireccionFisica>()
                .HasOne(d => d.Persona)
                .WithMany(p => p.DireccionesFisicas)
                .HasForeignKey(d => d.PersonaDocumentoIdentidad);
        }
    }
}