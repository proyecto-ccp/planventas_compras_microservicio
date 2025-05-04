

using AutoMapper;
using MediatR;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Dto;
using PlanesVentas.Dominio.Servicios.Planes;
using System.Net;

namespace PlanesVentas.Aplicacion.Planes.Consultas
{
    public class PlanesVentasConsultaHandler : IRequestHandler<PlanesVentasConsulta, PlanVentasListOut>
    {
        private readonly IMapper _mapper;
        private readonly Consultar _servicio;

        public PlanesVentasConsultaHandler(IMapper mapper, Consultar servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        public async Task<PlanVentasListOut> Handle(PlanesVentasConsulta request, CancellationToken cancellationToken)
        {
            PlanVentasListOut output = new() 
            { 
                PlanesVentas = []
            };

            try
            {

                var planes = await _servicio.Ejecutar() ?? [];

                if (planes.Count > 0)
                {
                    planes.ForEach(plan => output.PlanesVentas.Add(_mapper.Map<PlanVentaDto>(plan)));
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Consulta exitosa";
                    output.Status = HttpStatusCode.OK;
                }
                else 
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No hay planes de venta creados";
                    output.Status = HttpStatusCode.NotFound;
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
