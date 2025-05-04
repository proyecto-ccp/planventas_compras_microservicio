
using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;
using PlanesVentas.Infraestructura.Adaptadores.RepositorioGenerico;
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class PlanVentaRepositorio : IPlanVentaRepositorio
    {
        private readonly IRepositorioBase<PlanVenta> _repositorioPlanVenta;

        public PlanVentaRepositorio(IRepositorioBase<PlanVenta> repositorioPlanVenta)
        {
            _repositorioPlanVenta = repositorioPlanVenta;
        }

        public async Task<PlanVenta> Crear(PlanVenta planVenta)
        {
            return await _repositorioPlanVenta.Guardar(planVenta);
        }

        public Task<PlanVenta> ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlanVenta>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
