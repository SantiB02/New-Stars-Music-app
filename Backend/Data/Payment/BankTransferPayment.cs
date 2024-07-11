using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payment
{
    public class BankTransferPayment : IPaymentService
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing bank transfer payment of {amount}.");
        }
    }
}
