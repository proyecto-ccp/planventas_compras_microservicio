
using AutoMapper;
using MediatR;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Dto;
using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Servicios.Planes;
using PlanesVentas.Dominio.Servicios.Vendedores;
using System.Net;

namespace PlanesVentas.Aplicacion.Planes.Comandos
{
    public class AgregarVendedoresHandler : IRequestHandler<AgregarVendedores, PlanVentasOut>
    {
        private readonly IMapper _mapper;
        private readonly AgregarVendedor _servicioVendedores;
        private readonly ConsultarPlan _servicioPlan;

        public AgregarVendedoresHandler(IMapper mapper, AgregarVendedor servicioVendedores, ConsultarPlan servicioPlan) 
        {
            _mapper = mapper;
            _servicioVendedores = servicioVendedores;
            _servicioPlan = servicioPlan;
        }


        public async Task<PlanVentasOut> Handle(AgregarVendedores request, CancellationToken cancellationToken)
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
                    foreach (VendedorPlanVentaIn vendedor in request.Vendedores)
                    {
                        var vendedorAgregar = _mapper.Map<VendedorPlanVenta>(vendedor);
                        vendedorAgregar.IdPlanVenta = request.IdPlanVenta;
                        await _servicioVendedores.Ejecutar(vendedorAgregar);
                    }
                    output.PlanVenta.Vendedores = request.Vendedores;
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Vendedores asociados correctamente";
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
