
using MediatR;
using PlanesVentas.Aplicacion.Planes.Dto;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Aplicacion.Planes.Consultas
{
    [ExcludeFromCodeCoverage]
    public record PlanesVentasConsulta() : IRequest<PlanVentasListOut>;
    public record ProductosPlanVentasConsulta(
        [Required(ErrorMessage = "El campo IdPlanVenta es obligatorio")]
        Guid IdPlanVenta
        ) : IRequest<PlanVentasOut>;
    public record VendedoresPlanVentasConsulta(
        [Required(ErrorMessage = "El campo IdPlanVenta es obligatorio")]
        Guid IdPlanVenta
    ) : IRequest<PlanVentasOut>;

}
