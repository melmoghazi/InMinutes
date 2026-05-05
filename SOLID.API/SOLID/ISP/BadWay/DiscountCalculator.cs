namespace SOLID.API.SOLID.ISP.BadWay
{
    /// <summary>
    /// Imagine we decide that some discounts also come with "Loyalty Points" or "Free Shipping Coupons." 
    /// If we add these to the base DiscountStrategy, we force every single class to implement them, even if they don't apply.
    /// </summary>
    public abstract class DiscountStrategy
    {
        public abstract double ApplyDiscount(double amount);

        // ISP VIOLATION: Not every discount provides loyalty points or coupons!
        public abstract int CalculateLoyaltyPoints(double amount);
        public abstract string GetFreeCoupon();
    }

    public class RegularDiscount : DiscountStrategy
    {
        public override double ApplyDiscount(double amount) => amount - (amount * 0.10);

        // Regular users don't get points or coupons, but we are FORCED to implement this.
        public override int CalculateLoyaltyPoints(double amount) => 0;
        public override string GetFreeCoupon() => null;
    }
}
