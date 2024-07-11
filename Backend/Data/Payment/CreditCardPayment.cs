using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payment
{
    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}.");
        }
    }
}
