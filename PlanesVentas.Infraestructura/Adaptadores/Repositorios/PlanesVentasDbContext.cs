using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using PlanesVentas.Dominio.Entidades;
using Inventarios.Infraestructura.Adaptadores.Configuraciones;

namespace PlanesVentas.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class PlanesVentasDbContext : DbContext
    {
        public PlanesVentasDbContext(DbContextOptions<PlanesVentasDbContext> options): base(options){ }

        public DbSet<PlanVenta> PlanesVentas { get; set; }
        public DbSet<ProductoPlanVenta> ProductosPlanVentas { get; set; }
        public DbSet<VendedorPlanVenta> VendedoresPlanVentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanVentaConfiguracion());
        }
    }
}
