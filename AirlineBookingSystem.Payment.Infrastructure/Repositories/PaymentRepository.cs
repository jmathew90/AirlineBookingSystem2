using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using Dapper;
namespace AirlineBookingSystem.Payments.Infrastructure.Repositories
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly System.Data.IDbConnection _dbConnection;
        public PaymentRepository(System.Data.IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task ProcessPaymentAsync(Payment payment)
        {
            const string sql = @"Insert into Payments( Id,  BookingId,Amount, PaymentDate) Values (@Id, @BookingId, @Amount, @PaymentDate)";
            await _dbConnection.ExecuteAsync(sql, payment);
            

        }

        public Task RefundPaymentAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
