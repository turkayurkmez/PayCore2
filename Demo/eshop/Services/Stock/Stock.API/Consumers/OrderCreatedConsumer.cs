using MassTransit;
using MessageBus;

namespace Stock.API.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ILogger<OrderCreatedConsumer> logger;

        public OrderCreatedConsumer(IPublishEndpoint publishEndpoint, ILogger<OrderCreatedConsumer> logger)
        {
            this.publishEndpoint = publishEndpoint;
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            if (checkStock(context.Message.OrderItems))
            {
                logger.LogInformation("Ürün adedi, stoktan düşüldü ---- ");
                StockReserved stockReserved = new StockReserved();
                stockReserved.OrderId = context.Message.OrderId;
                stockReserved.OrderItems = context.Message.OrderItems;
                stockReserved.CustomerId = context.Message.CustomerId;

                await publishEndpoint.Publish(stockReserved);

            }
            else
            {
                logger.LogInformation("Ürün adedi, stoktan düşülemedi ---- ");

                StockNotReserved stockNotReserved = new StockNotReserved
                {
                    CustomerId = context.Message.CustomerId,
                    OrderId = context.Message.OrderId,
                    OrderItems = context.Message.OrderItems
                };

                await publishEndpoint.Publish(stockNotReserved);
            }

        }

        private bool checkStock(List<OrderItem> orderItems)
        {
            return new Random().Next(0, 10) % 2 == 0;

        }
    }
}
