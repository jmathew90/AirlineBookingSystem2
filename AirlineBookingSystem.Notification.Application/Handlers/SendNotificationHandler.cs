using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AirlineBookingSystem.Notification.Application.Commands;
using AirlineBookingSystem.Notification.Application.Interfaces;
namespace AirlineBookingSystem.Notification.Application.Handlers
{
    public class SendNotificationHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly INotificationService _notificationService;
        public SendNotificationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new AirlineBookingSystem.Notifications.Core.Entities.Notification
            {
                Id = new Random().Next(1, 1000),
                Recipient = request.Recipient,
                Message = request.Message,
                Type = request.Type
            };
            await _notificationService.SendNotificationAsync(notification);

        }

    }
}
