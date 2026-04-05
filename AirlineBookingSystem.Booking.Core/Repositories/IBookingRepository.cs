using AirlineBookingSystem.Bookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AirlineBookingSystem.Bookings.Core.Repositories
{
    public interface IBookingRepository
    {
        Task <Booking> GetBookingByIdAsync(int id);
        Task AddBookingsAsync(Booking booking);
    }
}
