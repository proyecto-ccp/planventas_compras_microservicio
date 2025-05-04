

using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;

namespace PlanesVentas.Dominio.Servicios.Productos
{
    public class ConsultarProductos(IProductosRepositorio productosRepositorio)
    {
        private readonly IProductosRepositorio _productosRepositorio = productosRepositorio;
        public async Task<List<ProductoPlanVenta>> Ejecutar(Guid id)
        {
            return await _productosRepositorio.ObtenerPorPlanVenta(id);
        }

    }
}
