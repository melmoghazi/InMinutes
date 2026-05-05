namespace SOLID.API.SOLID.ISP.CorrectWay
{
    /// <summary>
    /// Clients should not be forced to depend upon interfaces that they do not use.
    /// </summary>
    public interface IDiscountStrategy
    {
        double ApplyDiscount(double amount);
    }

    public interface ILoyaltyProvider
    {
        int CalculateLoyaltyPoints(double amount);
    }

    public interface ICouponProvider
    {
        string GetFreeCoupon();
    }
    //------------------------------------------------------------------------
    // Regular: Only does discounts
    public class RegularDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double amount) =>  amount - (amount * 0.10);
    }

    // Premium: Does discounts AND loyalty points
    public class PremiumDiscount : IDiscountStrategy, ILoyaltyProvider
    {
        public double ApplyDiscount(double amount) => amount - (amount * 0.20);
        public int CalculateLoyaltyPoints(double amount) => (int)(amount * 1); // 1 point per $
    }

    // VIP: Does everything
    public class VipDiscount : IDiscountStrategy, ILoyaltyProvider, ICouponProvider
    {
        public double ApplyDiscount(double amount) => amount - (amount * 0.50);
        public int CalculateLoyaltyPoints(double amount) => (int)(amount * 2); // 2 points per $
        public string GetFreeCoupon() => "FREE_LUNCH_VOUCHER";
    }
}
