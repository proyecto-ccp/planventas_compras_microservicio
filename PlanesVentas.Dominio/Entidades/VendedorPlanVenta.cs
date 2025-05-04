

namespace PlanesVentas.Dominio.Entidades
{
    public class VendedorPlanVenta : EntidadBaseInt
    {
        public Guid IdPlanVenta { get; set; }
        public Guid IdVendedor { get; set; }
    }
   
}
