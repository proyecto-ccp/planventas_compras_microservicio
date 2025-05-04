
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Aplicacion.Planes.Dto
{
    [ExcludeFromCodeCoverage]
    public class ProductoPlanVentaDto
    {
        public Guid IdPlanVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal ValorTotal { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProductoPlanVentaIn
    {
        public int IdProducto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
