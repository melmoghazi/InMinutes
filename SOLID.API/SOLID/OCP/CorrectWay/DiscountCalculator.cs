using SOLID.API.SOLID.SRP.BadWay;

namespace SOLID.API.SOLID.OCP.CorrectWay
{
    /// <summary>
    /// Open Close Principal (OCP)
    /// Open for extension Close for modification.
    /// The software entities (modules, classes, functions etc.)
    /// should be open for extension but closed for modification.
    /// </summary>
    public abstract class DiscountStrategy
    {
        public abstract double ApplyDiscount(double amount);
    }
    public class RegularDiscount : DiscountStrategy
    {
        public override double ApplyDiscount(double amount)
        { return amount - (amount * 0.10); }
    }

    public class PremiumDiscount : DiscountStrategy
    {
        public override double ApplyDiscount(double amount)
        { return amount - (amount * 0.20); }
    }

    public class VipDiscount : DiscountStrategy
    {
        public override double ApplyDiscount(double amount)
        { return amount - (amount * 0.50); }
    }
    //How to use it------------------------------------------------------
    public class DiscountCalculator
    {
        public double GetTotal(DiscountStrategy strategy, double amount)
        {
            return strategy.ApplyDiscount(amount);
        }
    }
    //run
    public class Program1
    {
        public static void Main1(string[] args)
        {
            //get customer type and use suitable discount class
            var calculator = new DiscountCalculator();
            
            //Regular customer -> new RegularDiscount
            double regularAmount = calculator.GetTotal(new RegularDiscount(), 100);
            Console.WriteLine($"Regular Customer Total: {regularAmount}");
            
            //Premium customer -> new PremiumDiscount
            double premiumAmount = calculator.GetTotal(new PremiumDiscount(), 100);
            Console.WriteLine($"Premium Customer Total: {premiumAmount}");
            
            //VIP customer -> new VipDiscount
            double vipAmount = calculator.GetTotal(new VipDiscount(), 100);
            Console.WriteLine($"VIP Customer Total: {vipAmount}");
        }
    }

}
