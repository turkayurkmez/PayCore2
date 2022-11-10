using MassTransit;
using MediatR;
using MessageBus;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Commands;
using Orders.API.Models;
using Orders.API.Queries;

namespace Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IMediator _mediator;

        public OrdersController(IPublishEndpoint publishEndpoint, IMediator mediator)
        {
            this.publishEndpoint = publishEndpoint;
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            var request = new GetOrders { CustomerId = customerId };
            var orders = await _mediator.Send(request);
            return Ok(orders);

        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            order.OrderState = OrderState.Pending;

            //1. Komutu kim çalıştıracak?
            // OrdersCommandHandler commandHandler = new OrdersCommandHandler();
            //2. Hangi komutu çalıştıracak?
            var command = new CreateOrder { CustomerId = order.CustomerId, CreatedDate = DateTime.Now, TotalPrice = 1200 };

            //commandHandler.Handle(command);
            _mediator.Send(command);

            //db'ye order Pending olarak yazılır.
            //ardından event fırlatılır.
            publishEndpoint.Publish(new OrderCreatedEvent
            {
                CustomerId = order.CustomerId,
                OrderId = order.Id,
                OrderItems = order.OrderItems.Select(od => new MessageBus.OrderItem { Price = od.Price, ProductId = od.ProductId, Stock = od.Stock }).ToList()
            });


            return Ok();
        }
    }
}


/*
 * 1. Sipariş Ekleme eventi fırlar. (OrderCreated)
2. Stocks API’si OrderCreated eventini consume eder.
3. Eğer yeterli stok varsa StockReserved event’i fırlar.
4. Eğer yeterli stok yoksa StockNotReserved event’i fırlar

 5.  Payment API’si StockReserved event’ini consume eder.

 6.  Eğer ödeme alabiliyorsa PaymentCompleted event’i fırlar.

1. Eğer ödeme alamıyorsa PaymentFailed event’i fırlar
2. Orders API PaymentCompleted eventini dinler ve işlem kapanır
3. Order API’si StockNotReserved eventini consume eder ve fırlarsa OrderFailed olarak db’de günceller.
4. Stocks API’si PaymentFailed eventini consume eder ve fırlarsa  stock’ları değiştirir.
5. Order API’si PaymentFailed eventini consume eder ve fırlarsa OrderFailed olarak db’de güncellenir.
 */