using Microsoft.EntityFrameworkCore;
using ITMFotomultas.Models;

namespace ITMFotomultas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Fotomulta> Fotomultas { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure Fotomulta to have nullable VehiculoId
            modelBuilder.Entity<Fotomulta>()
                .Property(f => f.VehiculoId)
                .IsRequired(false);
                
            // Update the relationship to be optional
            modelBuilder.Entity<Fotomulta>()
                .HasOne(f => f.Vehiculo)
                .WithMany(v => v.Fotomultas)
                .HasForeignKey(f => f.VehiculoId)
                .IsRequired(false);
                
            // Configure decimal precision for Valor property
            modelBuilder.Entity<Fotomulta>()
                .Property(f => f.Valor)
                .HasPrecision(18, 2);
                
            // Configure Imagen to have nullable FotomultaId
            modelBuilder.Entity<Imagen>()
                .Property(i => i.FotomultaId)
                .IsRequired(false);
                
            // Update the relationship to be optional
            modelBuilder.Entity<Imagen>()
                .HasOne(i => i.Fotomulta)
                .WithMany(f => f.Imagenes)
                .HasForeignKey(i => i.FotomultaId)
                .IsRequired(false);
        }
    }
} 