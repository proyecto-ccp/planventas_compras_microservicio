
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

        public async Task<PlanVenta> ObtenerPorId(Guid id)
        {
            return await _repositorioPlanVenta.BuscarPorLlave(id);  
        }

        public async Task<List<PlanVenta>> ObtenerTodos()
        {
            return await _repositorioPlanVenta.DarListado();
        }
    }
}
