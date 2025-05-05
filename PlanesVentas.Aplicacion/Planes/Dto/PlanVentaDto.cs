

using PlanesVentas.Aplicacion.Comun;
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Aplicacion.Planes.Dto
{
    [ExcludeFromCodeCoverage]
    public class PlanVentaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFinal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public List<ProductoPlanVentaIn> Productos { get; set; }
        public List<VendedorPlanVentaIn> Vendedores { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PlanVentasOut : BaseOut
    {
        public PlanVentaDto PlanVenta { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PlanVentasListOut : BaseOut
    {
        public List<PlanVentaDto> PlanesVentas { get; set; }
    }


}
