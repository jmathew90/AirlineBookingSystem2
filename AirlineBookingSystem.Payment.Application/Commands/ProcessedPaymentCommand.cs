using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace AirlineBookingSystem.Payments.Application.Commands
{
    public record ProcessedPaymentCommand(int BookingId,decimal amount): IRequest<int>;
    
}
