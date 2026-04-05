namespace AirlineBookingSystem.BuildingBlocks.Common
{
    public class EventBusContract
    {
        public const string FlightBookedQueue = "flight-booked-queue";
        public const string PaymentProcessedQueue = "payment-processed-queue";
        public const string NotificationSentQueue = "notification-sent-queue";
        public EventBusContract() { }
        public EventBusContract(string name) { }

    }
}
