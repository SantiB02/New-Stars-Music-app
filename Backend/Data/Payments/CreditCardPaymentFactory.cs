using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payments
{
    public class CreditCardPaymentFactory : PaymentFactory
    {
        public override IPayment CreatePayment()
        {
            return new CreditCardPayment();
        }
    }
}
