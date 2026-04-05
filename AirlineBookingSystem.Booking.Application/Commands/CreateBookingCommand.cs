using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Booking.Application.Commands
{
    public record CreateBookingCommand(int FlightId,string PassengerName,string SeatNumber):IRequest<int>;
    
}
