using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flights.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AirlineBookingSystem.Flights.Core.Entities;

namespace AirlineBookingSystem.Flight.Application.Handlers
{
    public  class CreateFlightHandler:IRequestHandler<CreateFlightCommand,int>
    {
        private  readonly IFlightRepository _flightRepository;
        public CreateFlightHandler(IFlightRepository flightRepository) 
        {
        _flightRepository = flightRepository;
        }

        public async Task<int> Handle(CreateFlightCommand command, CancellationToken cancellationToken)
        {
            var flight = new AirlineBookingSystem.Flights.Core.Entities.Flight
            {
                Id = new Random().Next(1, 1000),
                FlightNumber = command.FlightNumber,
                Origin = command.Origin,
                DepartureTime = command.DepartureTime,
                Destination = command.Destination,
                ArrivalTime = command.ArrivalTime
            };
            await _flightRepository.AddFlightAsync(flight);
            return flight.Id;
        }
    }
}
