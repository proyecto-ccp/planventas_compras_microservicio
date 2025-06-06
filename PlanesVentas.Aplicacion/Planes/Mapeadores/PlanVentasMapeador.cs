﻿
using AutoMapper;
using PlanesVentas.Aplicacion.Planes.Comandos;
using PlanesVentas.Aplicacion.Planes.Dto;
using PlanesVentas.Dominio.Entidades;

namespace PlanesVentas.Aplicacion.Planes.Mapeadores
{
    public class PlanVentasMapeador : Profile
    {
        public PlanVentasMapeador() 
        {
            CreateMap<PlanVenta, PlanVentaDto>().ReverseMap();
            CreateMap<CrearPlanVentas, PlanVenta>().ReverseMap();

            CreateMap<ProductoPlanVentaIn, ProductoPlanVenta>().ReverseMap();
            CreateMap<ProductoPlanVenta, ProductoPlanVentaIn>().ReverseMap();

            CreateMap<VendedorPlanVentaIn, VendedorPlanVenta>().ReverseMap();
            CreateMap<VendedorPlanVenta, VendedorPlanVentaIn>().ReverseMap();
        }

    }
}
