using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AirlineBookingSystem.Flight.Application.Queries;
using AirlineBookingSystem.Flights.Core.Entities;
using AirlineBookingSystem.Flights.Core.Repositories;

namespace AirlineBookingSystem.Flight.Application.Handlers
{
    public class GetFlightsHandler:IRequestHandler<GetAllFlightQuery,IEnumerable<AirlineBookingSystem.Flights.Core.Entities.Flight>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightsHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<AirlineBookingSystem.Flights.Core.Entities.Flight>> Handle(GetAllFlightQuery request,CancellationToken token)
        {

            return await _flightRepository.GetFlightAsync();
        }
    }
}
