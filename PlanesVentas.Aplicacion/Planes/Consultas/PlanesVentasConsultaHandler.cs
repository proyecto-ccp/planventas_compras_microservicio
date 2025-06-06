﻿

using AutoMapper;
using MediatR;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Dto;
using PlanesVentas.Dominio.Servicios.Planes;
using PlanesVentas.Dominio.Servicios.Productos;
using PlanesVentas.Dominio.Servicios.Vendedores;
using System.Net;

namespace PlanesVentas.Aplicacion.Planes.Consultas
{
    public class PlanesVentasConsultaHandler : IRequestHandler<PlanesVentasConsulta, PlanVentasListOut>
    {
        private readonly IMapper _mapper;
        private readonly ConsultarPlanes _servicioPlanes;
        private readonly ConsultarProductos _servicioProductos;
        private readonly ConsultarVendedor _servicioVendedor;

        public PlanesVentasConsultaHandler(IMapper mapper, ConsultarPlanes servicio, ConsultarProductos servicioProductos, ConsultarVendedor servicioVendedor)
        {
            _mapper = mapper;
            _servicioPlanes = servicio;
            _servicioProductos = servicioProductos;
            _servicioVendedor = servicioVendedor;   
        }

        public async Task<PlanVentasListOut> Handle(PlanesVentasConsulta request, CancellationToken cancellationToken)
        {
            PlanVentasListOut output = new() 
            { 
                PlanesVentas = []
            };

            try
            {

                var planes = await _servicioPlanes.Ejecutar() ?? [];

                if (planes.Count > 0)
                {
                    planes.ForEach(plan => output.PlanesVentas.Add(_mapper.Map<PlanVentaDto>(plan)));

                    foreach (PlanVentaDto plan in output.PlanesVentas) 
                    {
                        var productos = await _servicioProductos.Ejecutar(plan.Id) ?? [];
                        plan.Productos = _mapper.Map<List<ProductoPlanVentaIn>>(productos);

                        var vendedores = await _servicioVendedor.Ejecutar(plan.Id) ?? [];
                        plan.Vendedores = _mapper.Map<List<VendedorPlanVentaIn>>(vendedores);
                    }

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
