

using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;

namespace PlanesVentas.Dominio.Servicios.Planes
{
    public class Crear (IPlanVentaRepositorio planVentaRepositorio)
    {
        private readonly IPlanVentaRepositorio _planVentaRepositorio = planVentaRepositorio;

        public async Task<PlanVenta> Ejecutar(PlanVenta planVenta)
        {
            PlanVenta output;

            planVenta.Id = Guid.NewGuid();
            planVenta.FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            output = await _planVentaRepositorio.Crear(planVenta);
            return output;
        }
    }
}
