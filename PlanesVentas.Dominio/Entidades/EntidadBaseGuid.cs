
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public abstract class EntidadBaseGuid
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
