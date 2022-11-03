namespace MessageBus
{
    public class ProductPriceChangedEvent
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }

    }
}
