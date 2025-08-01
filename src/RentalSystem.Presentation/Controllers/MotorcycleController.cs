using Microsoft.AspNetCore.Mvc;
using RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases;
using RentalSystem.Communication.Requests.Motorcycle;

namespace RentalSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        [HttpPost("/motos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMotorcycle([FromBody] RequestCreateMotorcycleJson request, [FromServices] ICreateMotorcycleUseCase useCase)
        {
            await useCase.ExecuteAsync(request);
            return Created();
        }
    }
}
