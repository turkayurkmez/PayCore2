using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddProductToBasket(string userId, int productId, string name, decimal price, string imageUrl)
        {

            return Ok();

        }
    }
}
