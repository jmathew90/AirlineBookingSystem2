using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AirlineBookingSystem.Notification.Application.Commands
{
    public record SendNotificationCommand(string Recipient, string Message, string Type): IRequest;


}
