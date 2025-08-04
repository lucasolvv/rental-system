using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSystem.Communication.Requests.Rental;

namespace RentalSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        public async Task<IActionResult> CreateMotorcycleRental([FromBody] RequestCreateMotorcycleRentalJson request, [FromServices] ICreateRentalUseCase useCase)
        {
            await useCase.ExecuteAsync(request);
            return Created();
        }
    }
}
