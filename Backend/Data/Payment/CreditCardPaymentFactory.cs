using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payment
{
    public class CreditCardPaymentFactory : PaymentFactory
    {
        public override IPaymentService CreatePayment()
        {
            return new CreditCardPayment();
        }
    }
}
