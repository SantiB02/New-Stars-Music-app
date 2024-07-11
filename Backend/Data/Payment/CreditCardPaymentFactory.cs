using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payment
{
    public class CreditCardPaymentFactory : PaymentFactory
    {
        public override IPayment CreatePayment()
        {
            return new CreditCardPayment();
        }
    }
}
