

using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;

namespace PlanesVentas.Dominio.Servicios.Productos
{
    public class Agregar(IProductosRepositorio productosRepositorio)
    {
        private readonly IProductosRepositorio _productosRepositorio = productosRepositorio;

        public async Task<ProductoPlanVenta> Ejecutar(ProductoPlanVenta producto)
        {
            producto.FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            return await _productosRepositorio.Agregar(producto);
            
        }
    }
}
