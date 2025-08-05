using Microsoft.AspNetCore.Mvc;
using RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.DeleteMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.GetMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.UpdateMotorcycleUseCases;
using RentalSystem.Communication.Requests.Motorcycles;
using RentalSystem.Communication.Responses;
using RentalSystem.Exceptions.ExceptionBase;
using System.ComponentModel;

namespace RentalSystem.Presentation.Controllers
{
    [DisplayName("motos")]
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        [HttpPost("/motos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorOnValidationException), StatusCodes.Status400BadRequest)]
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

        [HttpPut("/motos/{id}/placa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateMotorcycle([FromRoute] string id, [FromBody] RequestGetMotorcycleByPlateJson newPlate,
            [FromServices] IUpdateMotorcycleUseCase useCase)
        {
            await useCase.ExecuteAsync(id, newPlate.Placa);
            return Ok(new ResponseSuccessJson("Moto atualizada com sucesso!"));
        }

        [HttpGet("/motos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMotorcycleById([FromRoute] string id, [FromServices] IGetMotorcycleUseCase useCase)
        {
            var motorcycle = await useCase.GetMotorcycleByIdAsync(id);
            return Ok(motorcycle);

        }

        [HttpDelete("/motos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMotorcycle([FromRoute] string id, [FromServices] IDeleteMotorcycleUseCase useCase)
        {
            await useCase.ExecuteAsync(id);
            return Ok();
        }
    }
}
