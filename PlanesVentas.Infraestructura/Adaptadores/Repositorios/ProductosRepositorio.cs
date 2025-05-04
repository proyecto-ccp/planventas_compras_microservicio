
using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Puertos.Repositorios;
using PlanesVentas.Infraestructura.Adaptadores.RepositorioGenerico;

namespace PlanesVentas.Infraestructura.Adaptadores.Repositorios
{
    public class ProductosRepositorio : IProductosRepositorio
    {
        private readonly IRepositorioBase<ProductoPlanVenta> _repositorioProducto;
        public ProductosRepositorio(IRepositorioBase<ProductoPlanVenta> repositorioProducto)
        {
            _repositorioProducto = repositorioProducto;
        }
        public async Task<List<ProductoPlanVenta>> ObtenerPorPlanVenta(Guid id)
        {
            return await _repositorioProducto.DarListadoPorCampos(x => x.IdPlanVenta == id);
        }
        public async Task<ProductoPlanVenta> Agregar(ProductoPlanVenta producto)
        {
            return await _repositorioProducto.Guardar(producto);
        }
    }
}
