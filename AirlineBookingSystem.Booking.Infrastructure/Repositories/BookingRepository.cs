using System.Data;
using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using Dapper;

namespace AirlineBookingSystem.Bookings.Infrastructure.Repositories
{
    public class BookingRepository: IBookingRepository
    {
        private readonly IDbConnection _dbConnection;
        public BookingRepository(IDbConnection dbConnection) {
            _dbConnection = dbConnection;
        }

        public async Task AddBookingsAsync(Booking booking)
        {
            const string sql = @"INSERT INTO Bookings (Id,FlightId, PassengerName,SeatNumber, BookingDate) VALUES (@Id,@FlightId, @PassengerName,@SeatNumber, @BookingDate)";
            await _dbConnection.ExecuteAsync(sql, booking);
        }

        public async Task<Booking> GetBookingByIdAsync(int Id)
        {
            const string sql = "Select * from Booking where Id = @Id";
            Booking ?bookings = await _dbConnection.QueryFirstOrDefaultAsync<Booking>(sql,new {Id = Id});
            return bookings!;
        }
    }
}
