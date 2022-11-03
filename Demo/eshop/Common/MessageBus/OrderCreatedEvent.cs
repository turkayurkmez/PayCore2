namespace MessageBus
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }

    }
}
