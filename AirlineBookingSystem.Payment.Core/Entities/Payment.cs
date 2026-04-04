namespace AirlineBookingSystem.Payments.Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public int BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Status { get; set; }

    }
}
