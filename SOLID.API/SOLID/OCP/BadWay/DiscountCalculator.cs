namespace SOLID.API.SOLID.OCP.BadWay
{
    public class DiscountCalculator
    {
        public double CalculateDiscount(string customerType, double amount)
        {
            if (customerType == "Regular")
            {
                return amount - (amount * 0.10);
            }
            else if (customerType == "Premium")
            {
                return amount - (amount * 0.20);
            }
            // To add "VIP", I MUST modify this existing, tested class.
            return 0;
        }
    }
}
