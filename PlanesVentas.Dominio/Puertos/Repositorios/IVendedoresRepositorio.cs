

using PlanesVentas.Dominio.Entidades;

namespace PlanesVentas.Dominio.Puertos.Repositorios
{
    public interface IVendedoresRepositorio
    {
        Task<List<VendedorPlanVenta>> ObtenerPorPlanVenta(Guid id);
        Task<VendedorPlanVenta> Agregar(VendedorPlanVenta vendedor);

    }
}
