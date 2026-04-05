using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Application.Queries;
using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace AirlineBookingSystem.Booking.Application.Handlers
{
    public class GetBookingHandler:IRequestHandler<GetBookingQuery, AirlineBookingSystem.Bookings.Core.Entities.Booking>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<AirlineBookingSystem.Bookings.Core.Entities.Booking> Handle(GetBookingQuery request,CancellationToken cancellationToken)
        {
            // Retrieve the booking by Id using the repository
            var booking = await _bookingRepository.GetBookingByIdAsync(request.Id);
            return booking;
        }
    }
}
