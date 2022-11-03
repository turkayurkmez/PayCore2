using Catalog.Application;
using Catalog.Application.DataTransferObjects.Request;
using MassTransit;
using MessageBus;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPublishEndpoint _publishEndpoint;


        public ProductsController(IProductService productService, IPublishEndpoint publishEndpoint)
        {
            _productService = productService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            //veritabanından ürünleri çek ve json olarak istemciye gönder.
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPut]
        public IActionResult DiscountProductPrice(ChangeProductPriceRequest changeProductPriceRequest)
        {
            //db'ye eklendi:
            _productService.ChangeProductPrice(changeProductPriceRequest);
            //event fırlatılacak:
            var @event = new ProductPriceChangedEvent
            {
                ProductId = changeProductPriceRequest.ProductId,
                ProductName = changeProductPriceRequest.ProductName,
                NewPrice = changeProductPriceRequest.NewPrice,
                OldPrice = changeProductPriceRequest.OldPrice,
            };

            _publishEndpoint.Publish(@event);
            return Ok(new { message = "Product price changed by vendor", product = changeProductPriceRequest });

        }
    }
}
