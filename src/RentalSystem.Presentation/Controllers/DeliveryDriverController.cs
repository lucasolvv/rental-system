using Microsoft.AspNetCore.Mvc;
using RentalSystem.Application.UseCases.DeliveryDrivers.CreateDeliveryDriverUseCases;
using RentalSystem.Application.UseCases.DeliveryDrivers.UpdateDriverCnhUseCases;
using RentalSystem.Communication.Requests.DeliveryDriver;
using System.ComponentModel;

namespace RentalSystem.Presentation.Controllers
{
    [DisplayName("entregadores")]
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
    }
}
