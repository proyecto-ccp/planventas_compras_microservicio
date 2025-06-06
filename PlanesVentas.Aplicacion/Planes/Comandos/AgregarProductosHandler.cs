﻿
using AutoMapper;
using MediatR;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Dto;
using PlanesVentas.Dominio.Entidades;
using PlanesVentas.Dominio.Servicios.Planes;
using PlanesVentas.Dominio.Servicios.Productos;
using System.Net;

namespace PlanesVentas.Aplicacion.Planes.Comandos
{
    public class AgregarProductosHandler : IRequestHandler<AgregarProductos, PlanVentasOut>
    {
        private readonly IMapper _mapper;
        private readonly AgregarProducto _servicioProductos;
        private readonly ConsultarPlan _servicioPlan;

        public AgregarProductosHandler(IMapper mapper, AgregarProducto servicioProductos, ConsultarPlan servicioPlan) 
        {
            _mapper = mapper;
            _servicioProductos = servicioProductos;
            _servicioPlan = servicioPlan;
        }     
        public async Task<PlanVentasOut> Handle(AgregarProductos request, CancellationToken cancellationToken)
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
                    foreach (ProductoPlanVentaIn producto in request.Productos)
                    {
                        var productoAgregar = _mapper.Map<ProductoPlanVenta>(producto);
                        productoAgregar.IdPlanVenta = request.IdPlanVenta;
                        await _servicioProductos.Ejecutar(productoAgregar);
                    }
                    output.PlanVenta.Productos = request.Productos;
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Productos asociados correctamente";
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
