namespace SOLID.API.SOLID.ISP.CorrectWay
{
    public class DiscountCalculator
    {
        public double GetTotal(IDiscountStrategy strategy, double amount)
        {
            // 1. Everyone gets the discount
            double finalAmount = strategy.ApplyDiscount(amount);
            Console.WriteLine($"Final Price: {finalAmount}");

            // 2. ONLY if the strategy supports Loyalty, process it
            if (strategy is ILoyaltyProvider loyaltyProvider)
            {
                int points = loyaltyProvider.CalculateLoyaltyPoints(amount);
                Console.WriteLine($"Points Earned: {points}");
            }

            // 3. ONLY if the strategy supports Coupons, process it
            if (strategy is ICouponProvider couponProvider)
            {
                Console.WriteLine($"Coupon Awarded: {couponProvider.GetFreeCoupon()}");
            }
            return finalAmount;
        }
    }

    public class Program2
    {
        public static void Main2()
        {
            //get customer type and use suitable discount class
            var calculator = new DiscountCalculator();
            
            //Regular customer -> new RegularDiscount
            Console.WriteLine("--- Regular Order ---");
            calculator.GetTotal(new RegularDiscount(), 100);

            //Premium customer -> new PremiumDiscount
            Console.WriteLine("--- Premium Order ---");
            calculator.GetTotal(new PremiumDiscount(), 100);

            //VIP customer -> new VipDiscount
            Console.WriteLine("\n--- VIP Order ---");
            calculator.GetTotal(new VipDiscount(), 100);
        }
    }
}
