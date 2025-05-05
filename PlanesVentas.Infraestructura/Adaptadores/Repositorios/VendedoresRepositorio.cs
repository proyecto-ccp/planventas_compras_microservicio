

using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;
using PlanesVentas.Infraestructura.Adaptadores.RepositorioGenerico;

namespace PlanesVentas.Infraestructura.Adaptadores.Repositorios
{
    public class VendedoresRepositorio : IVendedoresRepositorio
    {
        private readonly IRepositorioBase<VendedorPlanVenta> _repositorioVendedor;

        public VendedoresRepositorio(IRepositorioBase<VendedorPlanVenta> repositorioVendedor) 
        {
            _repositorioVendedor = repositorioVendedor;

        }
        public async Task<VendedorPlanVenta> Agregar(VendedorPlanVenta vendedor)
        {
            return await _repositorioVendedor.Guardar(vendedor);
        }

        public async Task<List<VendedorPlanVenta>> ObtenerPorPlanVenta(Guid id)
        {
            return await _repositorioVendedor.DarListadoPorCampos(x => x.IdPlanVenta == id);
        }
    }
}
