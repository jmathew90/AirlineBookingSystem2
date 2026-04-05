
using MediatR;

using AirlineBookingSystem.Notification.Application.Interfaces;
using MassTransit;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message;

namespace AirlineBookingSystem.Notification.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public NotificationService(IPublishEndpoint publishEndpoint) 
        {
            _publishEndpoint = publishEndpoint;

        }
        public async Task SendNotificationAsync(Notifications.Core.Entities.Notification notification)
        {
           Console.WriteLine($"Sending {notification.Type} notification to {notification.Recipient}: {notification.Message}");
            var notificationEvent = new NotificationEvent
            (
                notification.Recipient,
                notification.Message,
                notification.Type
            );
            await _publishEndpoint.Publish(notificationEvent);


        }
    }
}
