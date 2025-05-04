

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanesVentas.Dominio.Entidades;
using System.Diagnostics.CodeAnalysis;

namespace Inventarios.Infraestructura.Adaptadores.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class PlanVentaConfiguracion : IEntityTypeConfiguration<PlanVenta>
    {
        public void Configure(EntityTypeBuilder<PlanVenta> builder)
        {
            builder.ToTable("tbl_planesventas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .IsRequired();

            builder.Property(x => x.FechaInicio)
                .HasColumnName("fechainicio")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.FechaFinal)
                .HasColumnName("fechafinal")
                .HasColumnType("date")
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
