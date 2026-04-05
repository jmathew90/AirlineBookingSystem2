
using MediatR;

using AirlineBookingSystem.Notification.Application.Interfaces;

namespace AirlineBookingSystem.Notification.Application.Services
{
    public class NotificationService : INotificationService
    {
        public NotificationService() { }
        public async Task SendNotificationAsync(Notifications.Core.Entities.Notification notification)
        {
           Console.WriteLine($"Sending {notification.Type} notification to {notification.Recipient}: {notification.Message}");
        }
    }
}
