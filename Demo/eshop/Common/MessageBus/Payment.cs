namespace MessageBus
{
    public class PaymentCompletedEvent
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

    }

    public class PaymentFailedEvent
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}
