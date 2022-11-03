using MassTransit;
using MessageBus;

namespace Orders.API.Consumers
{
    public class PaymentFailedConsumer : IConsumer<PaymentFailedEvent>
    {
        private readonly ILogger<PaymentFailedConsumer> _logger;

        public PaymentFailedConsumer(ILogger<PaymentFailedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            _logger.LogInformation("Payment failed....");
            return Task.CompletedTask;
        }
    }
}
