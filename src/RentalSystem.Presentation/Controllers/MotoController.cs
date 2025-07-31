using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSystem.Application.UseCases.Motos.CreateMotoUseCases;
using RentalSystem.Communication.Requests.Motos;

namespace RentalSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        [HttpPost("/motos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMoto([FromBody] RequestCreateMotoJson request, [FromServices] ICreateMotoUseCase useCase)
        {
            await useCase.ExecuteAsync(request);
            return Created();
        }
    }
}
