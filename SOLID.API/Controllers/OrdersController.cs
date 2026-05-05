using SOLID.API.SOLID.ISP.CorrectWay;
using Microsoft.AspNetCore.Mvc;

namespace SOLID.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// High-level modules should not depend on low-level modules. Both should depend on abstractions.
    /// Abstractions should not depend on details.Details should depend on abstractions.
    public class OrdersController : ControllerBase
    {
        DiscountCalculator discountCalculator = new DiscountCalculator();
        private readonly DiscountCalculator _discountCalculator;

        IDiscountStrategy strategy = new VipDiscount();
        private readonly IDiscountStrategy _strategy;

        public OrdersController(DiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator; // The framework "injects" it for you!
        }
    }
}
