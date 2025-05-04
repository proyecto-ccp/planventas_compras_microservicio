
namespace PlanesVentas.Dominio.Entidades
{
    public class ProductoPlanVenta : EntidadBaseInt
    {
        public Guid IdPlanVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
