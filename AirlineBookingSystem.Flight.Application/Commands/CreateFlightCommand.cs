using System;
using System.Collections.Generic;
using System.Text;
using AirlineBookingSystem.Flights.Core.Entities;
using AirlineBookingSystem.Flights.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Flight.Application.Commands
{
    public record CreateFlightCommand(string FlightNumber, string Origin,string Destination, DateTime DepartureTime, DateTime ArrivalTime):IRequest<int>;
    
}
