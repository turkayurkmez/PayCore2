namespace Catalog.Application.DataTransferObjects.Request
{
    public class ChangeProductPriceRequest
    {
        public int ProductId { get; set; }
        public decimal? NewPrice { get; set; }
    }
}
