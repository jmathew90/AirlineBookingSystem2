

using AirlineBookingSystem.Bookings.Core.Entities;

using MediatR;

namespace AirlineBookingSystem.Booking.Application.Queries
{
    public record GetBookingQuery(int Id): IRequest<AirlineBookingSystem.Bookings.Core.Entities.Booking>;
  
}
