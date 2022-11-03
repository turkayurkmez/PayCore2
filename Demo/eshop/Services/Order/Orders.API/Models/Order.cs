namespace Orders.API.Models
{
    public enum OrderState
    {
        Pending,
        Completed,
        Failed,
        Canceled
    }
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public OrderState OrderState { get; set; }

    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }


    }
}
