using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AirlineBookingSystem.Flight.Application.Commands
{
    public record  DeleteFlightCommand(int Id):IRequest;
    
}
