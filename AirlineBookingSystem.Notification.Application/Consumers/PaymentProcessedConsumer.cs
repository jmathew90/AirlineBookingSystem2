using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message; 
using MediatR;
using MassTransit;
using AirlineBookingSystem.Notifications.Core.Repositories;
using RabbitMQ.Client;
using AirlineBookingSystem.Notification.Application.Commands;


namespace AirlineBookingSystem.Notification.Application.Consumers
{
    public  class PaymentProcessedConsumer:IConsumer<PaymentProcessedEvent>
    {
        private readonly IMediator _mediator;

        public PaymentProcessedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }   

        public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
        {
            var paymentProcessedEvent = context.Message;
            var message = $"Payment processed for Booking ID: {paymentProcessedEvent.BookingId}, Amount: {paymentProcessedEvent.Amount} was received sucessfully";
            //var message = context.Message;
            //// Handle the payment processed event, e.g., send a notification
            //Console.WriteLine($"Payment processed for Booking ID: {message.BookingId}, Amount: {message.Amount}");
            //// You can also use _mediator to send commands or queries if needed
            var command = new SendNotificationCommand("DlFundingAutherizationManagement@Nypa.gov", message, "Email");
            await _mediator.Send(command);

        }


    }
}
