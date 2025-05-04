

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanesVentas.Dominio.Entidades;
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Infraestructura.Adaptadores.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class ProductoPlanVentaConfiguracion : IEntityTypeConfiguration<ProductoPlanVenta>
    {
        public void Configure(EntityTypeBuilder<ProductoPlanVenta> builder)
        {
            builder.ToTable("tbl_productosplanesventas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.IdPlanVenta)
                .HasColumnName("idplanventas")
                .IsRequired();

            builder.Property(x => x.IdProducto)
                .HasColumnName("idproducto")
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .HasColumnName("valortotal")
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fecharegistro")
                .HasColumnType("timestamp(6)")
                .IsRequired();

            builder.Property(x => x.FechaModificacion)
                .HasColumnName("fechaactualizacion")
                .HasColumnType("timestamp(6)")
                .IsRequired(false);
        }
    }
}
