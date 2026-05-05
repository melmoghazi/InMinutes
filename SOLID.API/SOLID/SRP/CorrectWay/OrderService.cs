namespace SOLID.API.SOLID.SRP.CorrectWay
{
    public class CreateOrder
    {
        public CreateOrder() { }
    }
    /// <summary>
    /// Single Responsibility Principle (SRP)
    /// Class change for one reason only.
    /// </summary>
    public class ApplyDiscount
    {
        //get customer info (customer type for discount)
        //apply the discount to the order
    }

    public class PrintInvoice
    {
        public void print() { }
    }

    public class EmailSender
    {
        public void send() { }
    }

    public class CalculateTotal
    {
        public double calculateTotal() { return 0; }
    }

}
