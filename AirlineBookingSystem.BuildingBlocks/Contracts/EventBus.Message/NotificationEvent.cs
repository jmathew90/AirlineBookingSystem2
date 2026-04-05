using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message
{
    public  record NotificationEvent(string Recipient, string Message,string Type);
    
}
