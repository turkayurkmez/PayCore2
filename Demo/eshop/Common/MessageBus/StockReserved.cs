namespace MessageBus
{
    public class StockReserved
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class StockNotReserved
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
