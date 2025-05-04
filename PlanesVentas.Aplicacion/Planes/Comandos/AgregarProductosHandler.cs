
using AutoMapper;
using MediatR;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Dto;
using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Servicios.Productos;
using System.Net;

namespace PlanesVentas.Aplicacion.Planes.Comandos
{
    public class AgregarProductosHandler : IRequestHandler<AgregarProductos, PlanVentasOut>
    {
        private readonly IMapper _mapper;
        private readonly Agregar _servicioProductos;

        public AgregarProductosHandler(IMapper mapper, Agregar servicioProductos) 
        {
            _mapper = mapper;
            _servicioProductos = servicioProductos;
        }     
        public async Task<PlanVentasOut> Handle(AgregarProductos request, CancellationToken cancellationToken)
        {
            PlanVentasOut output = new();

            try
            {
                foreach (ProductoPlanVentaIn producto in request.Productos) 
                { 
                    var productoAgregar = _mapper.Map<ProductoPlanVenta>(producto);
                    productoAgregar.IdPlanVenta = request.IdPlanVenta;
                    await _servicioProductos.Ejecutar(productoAgregar);
                }
                
                output.Resultado = Resultado.Exitoso;
                output.Mensaje = "Productos asociados correctamente";
                output.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = string.Concat("Message: ", ex.Message, ex.InnerException is null ? "" : "-InnerException-" + ex.InnerException.Message);
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }
}
