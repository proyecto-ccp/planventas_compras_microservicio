
using PlanesVentas.Dominio.Entidades;

namespace PlanesVentas.Dominio.Puertos.Repositorios
{
    public interface IProductosRepositorio
    {
        Task<List<ProductoPlanVenta>> ObtenerPorPlanVenta(Guid id);
        Task<ProductoPlanVenta> Agregar(ProductoPlanVenta producto);
    }
}
