using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanesVentas.Aplicacion.Comun;
using PlanesVentas.Aplicacion.Planes.Comandos;
using PlanesVentas.Aplicacion.Planes.Consultas;
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

        /// <summary>
        /// Constructor del controlador
        /// </summary>
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
        [Route("")]
        [ProducesResponseType(typeof(PlanVentasOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> Crear([FromBody] CrearPlanVentas input)
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

        /// <summary>
        /// Consultar todos los planes de ventas 
        /// </summary>
        /// <response code="200"> 
        /// PlanVentasListOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(PlanVentasListOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ConsultarPlanes()
        {
            var output = await _mediator.Send(new PlanesVentasConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Asociar una lista de productos a un plan de ventas
        /// </summary>
        /// <response code="200"> 
        /// PlanVentasOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("{IdPlanVentas}/Productos")]
        [ProducesResponseType(typeof(PlanVentasOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> AsociarProductos([FromBody] List<ProductoPlanVentaIn> productos, [FromRoute] Guid IdPlanVentas)
        {
            var output = await _mediator.Send(new AgregarProductos(IdPlanVentas, productos));

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Consultar los productos a un plan de ventas
        /// </summary>
        /// <response code="200"> 
        /// PlanVentasOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpGet]
        [Route("{IdPlanVentas}/Productos")]
        [ProducesResponseType(typeof(PlanVentasOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ConsultarProductos([FromRoute] Guid IdPlanVentas)
        {
            var output = await _mediator.Send(new ProductosPlanVentasConsulta(IdPlanVentas));

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Asociar una lista de vendedores a un plan de ventas
        /// </summary>
        /// <response code="200"> 
        /// PlanVentasOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("{IdPlanVentas}/Vendedores")]
        [ProducesResponseType(typeof(PlanVentasOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> AsociarVendedores([FromBody] List<VendedorPlanVentaIn> vendedores, [FromRoute] Guid IdPlanVentas)
        {
            var output = await _mediator.Send(new AgregarVendedores(IdPlanVentas, vendedores));

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Consultar los productos a un plan de ventas
        /// </summary>
        /// <response code="200"> 
        /// PlanVentasOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpGet]
        [Route("{IdPlanVentas}/Vendedores")]
        [ProducesResponseType(typeof(PlanVentasOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ConsultarVendedores([FromRoute] Guid IdPlanVentas)
        {
            var output = await _mediator.Send(new VendedoresPlanVentasConsulta(IdPlanVentas));

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
