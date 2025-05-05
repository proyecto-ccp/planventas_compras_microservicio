

using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;

namespace PlanesVentas.Dominio.Servicios.Vendedores
{
    public class AgregarVendedor(IVendedoresRepositorio vendedoresRepositorio)
    {
        private readonly IVendedoresRepositorio _vendedoresRepositorio = vendedoresRepositorio;

        public async Task<VendedorPlanVenta> Ejecutar(VendedorPlanVenta vendedor)
        {
            vendedor.FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            return await _vendedoresRepositorio.Agregar(vendedor);
            
        }
    }
}
