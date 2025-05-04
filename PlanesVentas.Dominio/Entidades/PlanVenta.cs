

using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public class PlanVenta : EntidadBaseGuid
    {
        public string Nombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFinal { get; set; }

    }
}
