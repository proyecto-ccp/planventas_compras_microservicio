

using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;

namespace PlanesVentas.Dominio.Servicios.Vendedores
{
    public class ConsultarVendedor(IVendedoresRepositorio vendedoresRepositorio)
    {
        private readonly IVendedoresRepositorio _vendedoresRepositorio = vendedoresRepositorio;
        public async Task<List<VendedorPlanVenta>> Ejecutar(Guid id)
        {
            return await _vendedoresRepositorio.ObtenerPorPlanVenta(id);
        }

    }
}
