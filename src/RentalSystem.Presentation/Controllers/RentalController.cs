using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSystem.Application.UseCases.Rentals.CreateRentalUseCases;
using RentalSystem.Application.UseCases.Rentals.GetRentalUseCases;
using RentalSystem.Application.UseCases.Rentals.RentalReturnUseCases;
using RentalSystem.Communication.Requests.Rental;
using RentalSystem.Communication.Responses;
using System.ComponentModel;

namespace RentalSystem.Presentation.Controllers
{
    [DisplayName("locação")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDriversController : ControllerBase
    {
        [HttpPost("/locacao")]
        [ProducesResponseType(StatusCodes.Status201Created)]
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

        [HttpPut("/locacao/{id}/devolucao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReturnRental([FromRoute] string id, [FromBody] RequestRentalReturnJson requestRentalReturnJson, [FromServices] IRentalReturnUseCase useCase)
        {
            var rentalFinalCost = await useCase.ExecuteAsync(id, requestRentalReturnJson.Data_devolucao);
            return Ok(new ResponseSuccessJson($"Data de devolução informada com sucesso. Custo final: {rentalFinalCost}"));
        }
    }
}
