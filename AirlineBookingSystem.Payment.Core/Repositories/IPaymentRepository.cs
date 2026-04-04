using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingSystem.Payments.Core.Entities;
namespace AirlineBookingSystem.Payments.Core.Repositories
{
    internal interface IPaymentRepository
    {
        Task ProcessPaymentAsync(int id);
        Task RefundPaymentAsync(Payment payment);
       
    }
}
