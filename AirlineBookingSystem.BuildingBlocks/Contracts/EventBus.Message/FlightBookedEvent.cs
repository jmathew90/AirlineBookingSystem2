using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message
{
    public record FlightBookedEvent (int BookingId, int FlightId, string PassengerName, string SeatNumber, DateTime BookingDate);
    
}
