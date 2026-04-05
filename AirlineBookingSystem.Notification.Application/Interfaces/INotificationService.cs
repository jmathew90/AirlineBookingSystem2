using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Notification.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(AirlineBookingSystem.Notifications.Core.Entities.Notification notification);
    }
}
