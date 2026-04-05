using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingSystem.Payments.Core.Entities;
namespace AirlineBookingSystem.Payments.Core.Repositories
{
    public interface IPaymentRepository
    {
        Task ProcessPaymentAsync(Payment payment);
        Task RefundPaymentAsync(int i);
       
    }
}
