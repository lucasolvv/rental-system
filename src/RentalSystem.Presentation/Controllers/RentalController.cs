using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSystem.Application.UseCases.Rentals.CreateRentalUseCases;
using RentalSystem.Application.UseCases.Rentals.GetRentalUseCases;
using RentalSystem.Communication.Requests.Rental;

namespace RentalSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        [HttpPost("/locacao")]
        public async Task<IActionResult> CreateMotorcycleRental([FromBody] RequestCreateMotorcycleRentalJson request, [FromServices] ICreateRentalUseCase useCase)
        {
            await useCase.ExecuteAsync(request);
            return Created();
        }

        [HttpGet("/locacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRentals([FromServices] IGetRentalUseCase useCase)
        {
            var rentals = await useCase.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [HttpGet("/locacao/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRentalById([FromRoute] string id, [FromServices] IGetRentalUseCase useCase)
        {
            var rental = await useCase.GetRentalByIdAsync(id);
            return Ok(rental);
        }

        //[HttpPut("locacao/{id}/devolucao")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> ReturnRental([FromRoute] string id, [FromServices] IReturnRentalUseCase useCase)
        //{
        //    await useCase.ExecuteAsync(id);
        //    return Ok(new { message = "Locação devolvida com sucesso!" });
        //}
    }
}
