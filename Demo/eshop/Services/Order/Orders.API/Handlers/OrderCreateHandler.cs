using MediatR;
using Orders.API.Commands;

namespace Orders.API.Handlers
{
    public class OrderCreateHandler : IRequestHandler<CreateOrder>
    {
        public async Task<Unit> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            //create order entity to db
            return await Task.FromResult(Unit.Value);
        }
    }
}
