using SOLID.API.SOLID.OCP.CorrectWay;

namespace SOLID.API.SOLID.LSP.BadWay
{
    /// <summary>
    /// Liskov Substitution Principle (LSP)
    /// objects of a superclass should be replaceable 
    /// with objects of its subclasses without breaking the application
    /// </summary>
    public class FreeDiscount : DiscountStrategy
    {
        public override double ApplyDiscount(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
