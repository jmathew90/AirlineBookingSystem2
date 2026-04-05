using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AirlineBookingSystem.Flights.Core.Entities;
using AirlineBookingSystem.Flights.Core.Repositories;
using System.Runtime.CompilerServices;
using AirlineBookingSystem.Flight.Application.Commands;

namespace AirlineBookingSystem.Flight.Application.Handlers
{
    public  class DeleteFlightHandler: IRequestHandler <DeleteFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;

        public DeleteFlightHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task Handle(DeleteFlightCommand command, CancellationToken cancellationToken)
        {
            await _flightRepository.DeleteFlightAsync(command.Id);
        }
    }
}
