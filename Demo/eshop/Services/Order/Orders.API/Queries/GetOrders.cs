using MediatR;
using Orders.API.Models;

namespace Orders.API.Queries
{
    public class GetOrders : IRequest<IEnumerable<Order>>
    {
        public int CustomerId { get; set; }

    }
}
