using Merchanmusic.Data.Payment;
using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Services.Implementations
{
    public class PaymentService:IPaymentService
    {
        public void ProcessPayment(string paymentMethod, decimal amount)
        {
            PaymentFactory factory = paymentMethod switch
            {
                "CreditCard" => new CreditCardPaymentFactory(),
        
                "BankTransfer" => new BankTransferPaymentFactory(),
                _ => throw new ArgumentException("Invalid payment method")
            };

            IPaymentService payment = factory.CreatePayment();
            payment.ProcessPayment(amount);
        }
    }
}
