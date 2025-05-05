
using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;

namespace PlanesVentas.Dominio.Servicios.Planes
{
    public class ConsultarPlan(IPlanVentaRepositorio planVentaRepositorio)
    {
        private readonly IPlanVentaRepositorio _planVentaRepositorio = planVentaRepositorio;

        public async Task<PlanVenta> Ejecutar(Guid idPlanVentas)
        {
            return await _planVentaRepositorio.ObtenerPorId(idPlanVentas);
        }
    }
}
