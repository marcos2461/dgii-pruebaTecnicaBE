using DGII_PruebaTecnica.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DGII_PruebaTecnica.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<tipoIdentificacion> tipoIdentificacion => Set<tipoIdentificacion>();
        public DbSet<contribuyente> contribuyente => Set<contribuyente>();
        public DbSet<comprobantesFiscales> comprobantesFiscales => Set<comprobantesFiscales>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tipoIdentificacion>(x =>
            {
                x.HasMany(l => l.contribuyes)
                .WithOne(x => x.tipoIdentificacion)
                .HasPrincipalKey(x => x.id)
                .HasForeignKey(x => x.tipoIdentificacionId);

            });

            modelBuilder.Entity<tipoContribuyente>(x =>
            {
                x.HasMany(l => l.contribuyes)
                .WithOne(x => x.tipoContribuyente)
                .HasPrincipalKey(x => x.id)
                .HasForeignKey(x => x.tipoContribuyenteId);

            });

            modelBuilder.Entity<contribuyente>(x =>
            {
                x.HasMany(l => l.comprobantesFiscales)
                .WithOne(x => x.contribuyente)
                .HasPrincipalKey(x => x.id)
                .HasForeignKey(x => x.contribuyenteId);

            });

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
