using Microsoft.AspNetCore.Mvc;
using SOLID.API.SOLID.ISP.CorrectWay;

namespace SOLID.API.SOLID.DIP.CorrectWay
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IDiscountStrategy _strategy;

        public OrdersController(IDiscountStrategy strategy)
        {
            _strategy = strategy;// The framework "injects" it for you!
        }

        [HttpGet]
        public IActionResult Get()
        {
            var total = 100;
            var finalPrice = _strategy.ApplyDiscount(total);

            return Ok(finalPrice);
        }
    }
}
