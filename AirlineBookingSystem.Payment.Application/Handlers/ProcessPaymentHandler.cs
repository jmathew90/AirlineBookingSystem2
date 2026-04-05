using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AirlineBookingSystem.Payments.Application.Commands;
using MassTransit;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message; 



namespace AirlineBookingSystem.Payments.Application.Handlers
{
    public class ProcessPaymentHandler : IRequestHandler<ProcessedPaymentCommand, int>
    {
        private readonly AirlineBookingSystem.Payments.Core.Repositories.IPaymentRepository _paymentRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        public ProcessPaymentHandler(AirlineBookingSystem.Payments.Core.Repositories.IPaymentRepository paymentRepository, IPublishEndpoint publishEndpoint)
        {
            _paymentRepository = paymentRepository;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<int> Handle(ProcessedPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new AirlineBookingSystem.Payments.Core.Entities.Payment
            {
                Id = new Random().Next(1, 1000),
                BookingId = request.BookingId,
                Amount = request.amount,
                PaymentDate = DateTime.UtcNow
            };
            await _paymentRepository.ProcessPaymentAsync(payment);
            // Publish an event to notify other services about the processed payment
            await _publishEndpoint.Publish(new PaymentProcessedEvent(
            
                 payment.Id,
                 payment.BookingId,
                 payment.Amount,
                 payment.PaymentDate
           ));
            return payment.Id;

        }

    }
}
