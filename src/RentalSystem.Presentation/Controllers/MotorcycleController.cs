using Microsoft.AspNetCore.Mvc;
using RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.GetMotorcycleUseCases;
using RentalSystem.Communication.Responses;
using RentalSystem.Communication.Requests.Motorcycles;

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

        [HttpGet("/motos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMotorcycles([FromServices] IGetMotorcycleUseCase useCase, 
            [FromQuery] RequestGetMotorcycleByPlateJson request)
        {
            var motorcycles = await useCase.ExecuteAsync(request);

            return Ok(motorcycles);
        }
    }
}
