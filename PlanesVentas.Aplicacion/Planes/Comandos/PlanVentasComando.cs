

using MediatR;
using PlanesVentas.Aplicacion.Planes.Dto;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Aplicacion.Planes.Comandos
{
    [ExcludeFromCodeCoverage]
    public record CrearPlanVentas(
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        string Nombre,
        [Required(ErrorMessage = "El campo FechaInicio es obligatorio")]
        DateOnly FechaInicio,
        [Required(ErrorMessage = "El campo FechaFinal es obligatorio")]
        DateOnly FechaFinal
        ) : IRequest<PlanVentasOut>;

    public record AgregarProductos(
        [Required(ErrorMessage = "El campo IdPlanVenta es obligatorio")]
        Guid IdPlanVenta,
        [Required(ErrorMessage = "Los productos son obligatorios")]
        List<ProductoPlanVentaIn> Productos
        ) : IRequest<PlanVentasOut>;


}
