using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Booking.Api.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] CreateBookingCommand command)
        {
            var id = await _mediator.Send(command);

            // Implement the logic to create a booking
            return CreatedAtAction(nameof(GetBookingById), new { id }, command);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _mediator.Send(new GetBookingQuery(id));
            // Implement the logic to retrieve a booking by ID
            return Ok(booking);
        }

    }
}
