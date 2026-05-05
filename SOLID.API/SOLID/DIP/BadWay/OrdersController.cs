using SOLID.API.SOLID.ISP.CorrectWay;
using Microsoft.AspNetCore.Mvc;

namespace SOLID.API.DIP.BadWay
{
    [Route("api/[controller]")]
    [ApiController]
    /// High-level modules should not depend on low-level modules. Both should depend on abstractions.
    /// Abstractions should not depend on details.Details should depend on abstractions.
    public class OrdersController : ControllerBase
    {
        IDiscountStrategy _strategy = new VipDiscount();        

        [HttpGet]
        public IActionResult Get()
        {
            var total = 100;
            var finalPrice = _strategy.ApplyDiscount(total);

            return Ok(finalPrice);
        }
    }
}