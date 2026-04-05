using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message
{
    public record PaymentProcessedEvent(int PaymentId, int BookingId, decimal Amount, DateTime PaymentDate);
    
}
