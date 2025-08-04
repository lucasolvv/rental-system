using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSystem.Application.UseCases.DeliveryDrivers.CreateDeliveryDriverUseCases;
using RentalSystem.Application.UseCases.DeliveryDrivers.UpdateDriverCnhUseCases;
using RentalSystem.Application.UseCases.Motorcycles.UpdateMotorcycleUseCases;
using RentalSystem.Communication.Requests.DeliveryDriver;

namespace RentalSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDriverController : ControllerBase
    {
        [HttpPost("/entregadores")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateDeliveryDriver([FromBody] RequestCreateDeliveryDriverJson request,
            [FromServices] ICreateDeliveryDriverUseCase useCase)
        {
            await useCase.ExecuteAsync(request);
            return Created();
        }

        [HttpPost("/entregadores/{id}/cnh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateDriverCnh([FromRoute] string id, [FromBody] RequestUpdateDriverCnhJson request,
            [FromServices] IUpdateDriverCnhUseCase useCase)
        {
            await useCase.ExecuteAsync(id, request);
            return Ok();
        }

        //[HttpGet("/entregadores")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllDeliveryDrivers([FromServices] IGetDeliveryDriverUseCase useCase)
        //{
        //    var drivers = await useCase.ExecuteAsync();
        //    return Ok(drivers);
        //}
    }
}
