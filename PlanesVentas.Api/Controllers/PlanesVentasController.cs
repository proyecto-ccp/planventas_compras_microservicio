using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Comandos;
using PlanesVentas.Aplicacion.Planes.Dto;

namespace PlanesVentas.Api.Controllers
{
    /// <summary>
    /// Controlador de inventarios
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PlanesVentasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanesVentasController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear plan ventas
        /// </summary>
        /// <response code="200"> 
        /// PlanVentasOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("Crear")]
        [ProducesResponseType(typeof(PlanVentasOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> Ingresar([FromBody] CrearPlanVentas input)
        {
            var output = await _mediator.Send(input);

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }
    }
}
