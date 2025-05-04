
using AutoMapper;
using MediatR;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Dto;
using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Servicios.Planes;
using System.Net;

namespace PlanesVentas.Aplicacion.Planes.Comandos
{
    public class CrearPlanVentasHandler : IRequestHandler<CrearPlanVentas, PlanVentasOut>
    {
        private readonly IMapper _mapper;
        private readonly Crear _servicio;

        public CrearPlanVentasHandler(IMapper mapper, Crear servicio) 
        {
            _mapper = mapper;
            _servicio = servicio;
        }
        public async Task<PlanVentasOut> Handle(CrearPlanVentas request, CancellationToken cancellationToken)
        {
            PlanVentasOut output = new();

            try
            {
                var planVenta = _mapper.Map<PlanVenta>(request);
                output.PlanVenta = _mapper.Map<PlanVentaDto>(await _servicio.Ejecutar(planVenta));
                output.PlanVenta.Productos = [];
                output.Resultado = Resultado.Exitoso;
                output.Mensaje = "Plan de ventas creado correctamente";
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
