using MassTransit;
using MessageBus;
using Orders.API.Models;

namespace Orders.API.Consumers
{
    public class StockNotReservedConsumer : IConsumer<StockNotReserved>
    {
        private ILogger<StockNotReserved> logger;

        public StockNotReservedConsumer(ILogger<StockNotReserved> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<StockNotReserved> context)
        {
            var order = new Order();
            order.OrderState = OrderState.Failed;
            logger.LogInformation("Stock rezerve edilemedi sipariş hata verdi");
            return Task.CompletedTask;
        }
    }
}
