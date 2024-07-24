using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payments
{
    public class BankTransferPayment : Payment
    {
        public string Bank {  get; set; }
        public override bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing bank transfer payment of {amount}.");
            return true; // el pago es correcto (simulación)
        }
    }
}
