using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Application.Queries;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message;
using MassTransit;
namespace AirlineBookingSystem.Booking.Application.Consumers
{
    public class NotificationEventConsumer:IConsumer<NotificationEvent>
    {
        public async Task Consume(ConsumeContext<NotificationEvent> context)
        {
            var notificationEvent = context.Message;
            
            // Handle the notification event, e.g., log it or send an email
            Console.WriteLine($"Received notification: {notificationEvent.Recipient},"+ $"Message={notificationEvent.Message},Type={notificationEvent.Type}");
            // You can also use MediatR to send a command or query based on the notification
            // For example, you could send a command to create a booking based on the notification
            // await _mediator.Send(new CreateBookingCommand(...));
            await Task.CompletedTask;
        }
    }
}
