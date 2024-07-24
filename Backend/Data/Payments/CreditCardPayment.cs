using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payments
{
    public class CreditCardPayment : Payment
    {
        public int Installments { get; set; }
        public decimal AmountPerInstallment { get; set; }

        public bool ProcessPayment(decimal amount, int installments)
        {
            Console.WriteLine($"Processing credit card payment of {amount} in {installments} installments.");
            return true; // el pago es correcto (simulación)
        }
    }
}
