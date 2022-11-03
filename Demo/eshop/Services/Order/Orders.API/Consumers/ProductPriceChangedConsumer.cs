using MassTransit;
using MessageBus;

namespace Orders.API.Consumers
{
    public class ProductPriceChangedConsumer : IConsumer<ProductPriceChangedEvent>
    {
        private readonly ILogger<ProductPriceChangedConsumer> _logger;

        public ProductPriceChangedConsumer(ILogger<ProductPriceChangedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ProductPriceChangedEvent> context)
        {
            _logger.LogInformation($"{context.Message.ProductName} isimli ürünün fiyatı; {context.Message.OldPrice} TL'den {context.Message.NewPrice} TL'ye değişti. Aradaki fark olan {context.Message.OldPrice - context.Message.NewPrice} TL hesabınıza tanımlandı");
            return Task.CompletedTask;
        }
    }
}
