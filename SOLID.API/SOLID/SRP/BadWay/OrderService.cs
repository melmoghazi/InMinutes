namespace SOLID.API.SOLID.SRP.BadWay
{
    public class OrderService
    {
        public void CreateOrder() { }
        public void ApplyDiscount() 
        {
            Console.WriteLine("Applying discount to order...");
        }
        public void PrintInvoice() 
        { 
            Console.WriteLine("Invoice for Order");
        }
        public void SendEmail() 
        {
            Console.WriteLine("Sending email to customer...");
        }
        public double CalculateTotal(Order order) 
        {
            return 100; 
        }
    }

    public class Order
    {
        // Order properties like List<OrderItem>, CustomerInfo, etc.
    }
}
