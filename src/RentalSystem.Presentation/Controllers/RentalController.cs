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
    [ApiController]
    [Route("locações")]
    [DisplayName("Locações")]
    public class DeliveryDriversController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMotorcycleRental([FromBody] RequestCreateMotorcycleRentalJson request, [FromServices] ICreateRentalUseCase useCase)
        {
            await useCase.ExecuteAsync(request);
            return Created();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRentals([FromServices] IGetRentalUseCase useCase)
        {
            var rentals = await useCase.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRentalById([FromRoute] string id, [FromServices] IGetRentalUseCase useCase)
        {
            var rental = await useCase.GetRentalByIdAsync(id);
            return Ok(rental);
        }

        [HttpPut("{id}/devolucao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReturnRental([FromRoute] string id, [FromBody] RequestRentalReturnJson requestRentalReturnJson, [FromServices] IRentalReturnUseCase useCase)
        {
            var rentalFinalCost = await useCase.ExecuteAsync(id, requestRentalReturnJson.Data_devolucao);
            return Ok(new ResponseSuccessJson($"Data de devolução informada com sucesso. Custo final: {rentalFinalCost}"));
        }
    }
}
