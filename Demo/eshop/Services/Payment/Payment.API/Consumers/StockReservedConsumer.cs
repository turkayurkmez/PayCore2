using MassTransit;
using MessageBus;

namespace Payment.API.Consumers
{
    public class StockReservedConsumer : IConsumer<StockReserved>
    {
        private readonly ILogger<StockReservedConsumer> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public StockReservedConsumer(ILogger<StockReservedConsumer> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<StockReserved> context)
        {
            if (checkPayment())
            {

                var paymentCompletedEvent = new PaymentCompletedEvent
                {
                    CustomerId = context.Message.CustomerId,
                    OrderId = context.Message.OrderId
                };
                await _publishEndpoint.Publish(paymentCompletedEvent);

            }
            else
            {
                var paymentFailedEvent = new PaymentFailedEvent
                {
                    CustomerId = context.Message.CustomerId,
                    OrderId = context.Message.OrderId
                };

                await _publishEndpoint.Publish(paymentFailedEvent);
            }
        }

        private bool checkPayment()
        {
            return new Random().Next(1, 10) % 2 == 0;
        }
    }
}
