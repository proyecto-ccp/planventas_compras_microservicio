

using PlanesVentas.Dominio.Entidades;

namespace PlanesVentas.Dominio.Puertos.Repositorios
{
    public interface IPlanVentaRepositorio
    {
        Task<PlanVenta> ObtenerPorId(Guid id);
        Task<List<PlanVenta>> ObtenerTodos();
        Task<PlanVenta> Crear(PlanVenta planVenta);
    }
}
