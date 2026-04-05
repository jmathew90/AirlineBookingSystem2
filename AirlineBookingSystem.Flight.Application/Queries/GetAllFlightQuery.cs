using MediatR;
using AirlineBookingSystem.Flights.Core.Entities;

namespace AirlineBookingSystem.Flight.Application.Queries
{
    public record  GetAllFlightQuery: IRequest<IEnumerable<AirlineBookingSystem.Flights.Core.Entities.Flight>>;

}
