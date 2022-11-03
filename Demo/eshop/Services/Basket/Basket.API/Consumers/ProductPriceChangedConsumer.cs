using MassTransit;
using MessageBus;

namespace Basket.API.Consumers
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
            _logger.LogInformation($"Sepetinizde bulunan {context.Message.ProductName} isimli ürüne {context.Message.OldPrice - context.Message.NewPrice} TL indirim yapılmıştır");
            return Task.CompletedTask;
        }
    }
}
