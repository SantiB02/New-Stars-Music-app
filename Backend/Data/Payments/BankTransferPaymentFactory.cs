using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payments
{
    public class BankTransferPaymentFactory : PaymentFactory
    {
        public override IPayment CreatePayment()
        {
            return new BankTransferPayment();
        }
    }
}
