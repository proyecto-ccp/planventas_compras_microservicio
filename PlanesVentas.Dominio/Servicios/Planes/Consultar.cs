
using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;

namespace PlanesVentas.Dominio.Servicios.Planes
{
    public class Consultar(IPlanVentaRepositorio planVentaRepositorio)
    {
        private readonly IPlanVentaRepositorio _planVentaRepositorio = planVentaRepositorio;

        public async Task<List<PlanVenta>> Ejecutar()
        {
            return await _planVentaRepositorio.ObtenerTodos();
        }

    }
}
