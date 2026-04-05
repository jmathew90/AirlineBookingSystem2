using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AirlineBookingSystem.Payment.Application.Commands
{
    public record RefundPaymentCommand (int PaymentId) : MediatR.IRequest;

}
