using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingSystem.Notifications.Core.Entities;

namespace AirlineBookingSystem.Notifications.Core.Repositories
{
    public interface INotificationRepository
    {
        
        Task logNotificationAsync(Notification notification);
       


    }
}
