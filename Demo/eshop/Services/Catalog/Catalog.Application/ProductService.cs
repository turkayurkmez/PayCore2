using Catalog.Application.DataTransferObjects.Request;
using Catalog.Application.DataTransferObjects.Response;
using Catalog.DataAccess;

namespace Catalog.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void ChangeProductPrice(ChangeProductPriceRequest changeProductPriceRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDisplayResponse> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products.Select(p => new ProductDisplayResponse
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Price = p.Price
            });


        }
    }
}
