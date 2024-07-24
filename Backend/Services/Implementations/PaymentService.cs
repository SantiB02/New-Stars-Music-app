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
                "Credit Card" => new CreditCardPaymentFactory(),
        
                "Bank Transfer" => new BankTransferPaymentFactory(),
                _ => throw new ArgumentException("Invalid payment method")
            };

            IPayment payment = factory.CreatePayment();
            payment.ProcessPayment(amount);
        }
    }
}
