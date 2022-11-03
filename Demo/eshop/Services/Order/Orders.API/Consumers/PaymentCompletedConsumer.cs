using MassTransit;
using MessageBus;

namespace Orders.API.Consumers
{

    public class PaymentCompletedConsumer : IConsumer<PaymentCompletedEvent>
    {

        private readonly ILogger<PaymentCompletedConsumer> _logger;

        public PaymentCompletedConsumer(ILogger<PaymentCompletedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            _logger.LogInformation("Ödeme tamamlandi Sipariş durumu güncellendi");
            return Task.CompletedTask;
        }
    }
}
