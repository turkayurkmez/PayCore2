using MediatR;

namespace Orders.API.Commands
{
    public class CreateOrder : IRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShipAddress { get; set; }
        public decimal? TotalPrice { get; set; }

    }
}
