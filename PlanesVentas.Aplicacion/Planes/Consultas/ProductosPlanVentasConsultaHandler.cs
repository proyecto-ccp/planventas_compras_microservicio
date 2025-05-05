
using AutoMapper;
using MediatR;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Dto;
using PlanesVentas.Dominio.Servicios.Planes;
using PlanesVentas.Dominio.Servicios.Productos;
using System.Net;

namespace PlanesVentas.Aplicacion.Planes.Consultas
{
    public class ProductosPlanVentasConsultaHandler : IRequestHandler<ProductosPlanVentasConsulta, PlanVentasOut>
    {
        private readonly IMapper _mapper;
        private readonly ConsultarPlan _servicioPlan;
        private readonly ConsultarProductos _servicioProductos;

        public ProductosPlanVentasConsultaHandler(IMapper mapper, ConsultarPlan servicio, ConsultarProductos servicioProductos) 
        {
            _mapper = mapper;
            _servicioPlan = servicio;
            _servicioProductos = servicioProductos;
        }
        public async Task<PlanVentasOut> Handle(ProductosPlanVentasConsulta request, CancellationToken cancellationToken)
        {
            PlanVentasOut output = new()
            {
                PlanVenta = new PlanVentaDto()
            };
            output.PlanVenta.Vendedores = [];
            output.PlanVenta.Productos = [];

            try
            {
                var plan = await _servicioPlan.Ejecutar(request.IdPlanVenta);

                if (plan is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No hay plan de venta creado";
                    output.Status = HttpStatusCode.NotFound;
                }
                else 
                {
                    output.PlanVenta = _mapper.Map<PlanVentaDto>(plan);

                    var productos = await _servicioProductos.Ejecutar(request.IdPlanVenta) ?? [];
                    output.PlanVenta.Productos = _mapper.Map<List<ProductoPlanVentaIn>>(productos);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Consulta exitosa";
                    output.Status = HttpStatusCode.OK;
                }


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
