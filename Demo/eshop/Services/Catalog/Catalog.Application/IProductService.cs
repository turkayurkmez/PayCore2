using Catalog.Application.DataTransferObjects.Request;
using Catalog.Application.DataTransferObjects.Response;

namespace Catalog.Application
{
    public interface IProductService
    {
        IEnumerable<ProductDisplayResponse> GetAllProducts();
        void ChangeProductPrice(ChangeProductPriceRequest changeProductPriceRequest);

    }
}
