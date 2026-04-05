using Microsoft.AspNetCore.Mvc;
using MediatR;


using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Application.Queries;
namespace AirlineBookingSystem.Flight.Api.Controllers
{
    [ApiController]
    [Route("api/Flight")]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlight()
        {
            var flights = await _mediator.Send(new GetAllFlightQuery());
            return Ok(flights);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
        {
            var flightId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllFlightQuery), new { flightId }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _mediator.Send(new DeleteFlightCommand(id));
            return NoContent();

        }
    }
}
