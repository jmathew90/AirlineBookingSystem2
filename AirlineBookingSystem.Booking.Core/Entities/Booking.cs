namespace AirlineBookingSystem.Bookings.Core.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string? PassengerName { get; set; }
        public DateTime BookingDate { get; set; }
        public string? SeatNumber { get; set; }
    }
}
