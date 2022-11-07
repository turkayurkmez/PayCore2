using MediatR;
using Orders.API.Models;
using Orders.API.Queries;

namespace Orders.API.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrders, IEnumerable<Order>>
    {
        public async Task<IEnumerable<Order>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            //var orders = fakeRepo.GetOrders(request.CustomerId);
            return await Task.FromResult(new List<Order>() { new Order { Id = 1, CustomerId = 3, OrderState = OrderState.Completed } });


        }
    }
}
