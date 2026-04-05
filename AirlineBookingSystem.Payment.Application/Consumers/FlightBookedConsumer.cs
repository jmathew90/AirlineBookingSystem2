using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MassTransit;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message;

using AirlineBookingSystem.Payments.Application.Commands;


namespace AirlineBookingSystem.Payment.Application.Consumers
{
    public class FlightBookedConsumer:IConsumer<FlightBookedEvent>
    {
        private readonly IMediator _mediator;
        public FlightBookedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<FlightBookedEvent> context)
        {
            var flightBookedEvent = context.Message;
            var command = new ProcessedPaymentCommand(flightBookedEvent.BookingId, 200.00m);
            await _mediator.Send(command);
           
        }

    }
}
